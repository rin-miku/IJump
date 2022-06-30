using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksPlatform : MonoBehaviour
{
    Animator animator;
    private float countTime;
    private float spawnTime;
    private bool isOnBlocks;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spawnTime = Random.Range(1.0f,4.0f);
        isOnBlocks = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Player");
        {
            animator.Play("Blocks_HitTop");
        }
        isOnBlocks = true;
    }
    public void SpawnBlocks()
    {
        if(isOnBlocks)
        {
            countTime += Time.deltaTime;
            if (countTime >= spawnTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
