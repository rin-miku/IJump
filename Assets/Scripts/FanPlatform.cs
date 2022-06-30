using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        {
            animator.Play("FanPlatform");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        {
            animator.Play("FanPlatform_Idle");
        }
    }
}
