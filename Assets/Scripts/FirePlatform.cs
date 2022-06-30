using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : MonoBehaviour
{
    new private BoxCollider2D collider2D;
    private float countTime;
    public static float onTime;
    public static float offTime;
    public bool isFireOn;
    // Start is called before the first frame update
    void Start()
    {
        isFireOn = false;
        onTime = Random.Range(1f, 2f);
        offTime = Random.Range(2f, 6f);
        collider2D = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        FireAnimation();
    }
    public void FireAnimation()
    {
        countTime += Time.deltaTime;
        if (countTime >= offTime && isFireOn == false)
        {
            isFireOn = true;
            countTime = 0f;
            collider2D.enabled = false;
        }
        if (countTime >= onTime && isFireOn == true)
        {
            isFireOn = false;
            countTime = 0f;
            collider2D.enabled = true;
        }
    }
}
