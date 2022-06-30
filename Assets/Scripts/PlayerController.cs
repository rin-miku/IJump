using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPun
{
    new Rigidbody2D rigidbody;
    Animator animator;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    public Text nameText;

    private float xVelocity;
    public bool isOnGround;
    public bool isDead;
    private bool isFirstJump;
    private bool isSecondJump;

    public float speed;
    public float checkRadius;
    public LayerMask platformLayer;
    public GameObject groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(photonView.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
        }
        else
        {
            nameText.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platformLayer);
        Movement();
        Animation();
        Portal();
        Jump();
    }
    private void Portal()   // LeftWall RightWall
    {
        if(transform.position.x > 4.7f)
        {
            transform.position = new Vector3 (-4.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -4.7f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && isFirstJump)
        {
            isFirstJump = false;
            if (rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = Vector2.up * 10;
                animator.SetBool("isSecondJump", true);
                animator.SetBool("isFirstJump", false);
            }
        }
        if (Input.GetMouseButtonDown(0) && isOnGround && !isFirstJump)
        {
            rigidbody.velocity = Vector2.up * 8;
            isFirstJump = true;
            animator.SetBool("isFirstJump", true);
            animator.SetBool("isSecondJump", false);
        }
    }

    private void Movement()
    {
#if UNITY_EDITOR
        xVelocity = Input.GetAxisRaw("Horizontal");
#else
        xVelocity = Input.acceleration.x;
        speed = 15;
#endif
        rigidbody.velocity = new Vector2(xVelocity * speed, rigidbody.velocity.y);
        if(xVelocity != 0)
        {
            //transform.localScale = new Vector3(xVelocity, 1, 1);
            
            if(xVelocity < 0)
            {
                //spriteRenderer.flipX = true;
                nameText.transform.rotation = new Quaternion(0, 180, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(xVelocity > 0)
            {
                //spriteRenderer.flipX = false;
                nameText.transform.rotation = new Quaternion(0, 0, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
            }
            
        }
    }

    private void Animation()
    {
        animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
        if(rigidbody.velocity.y < 0)
        {
            animator.SetBool("isOnGround", isOnGround);
            animator.SetBool("isFirstJump", false);
            animator.SetBool("isSecondJump", false);
        }
    }

    private void PlayerDead()
    {
        boxCollider.isTrigger = true;
        rigidbody.gravityScale = 3;
        isDead = true;
        GameManager2.GameOver(isDead);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            animator.SetTrigger("dead");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            animator.SetTrigger("dead");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("JumpPlatform"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.y, 12f);
        }
    }
}
