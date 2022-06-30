using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator animator;
    private float countTime;
    private float onTime;
    private float offTime;
    public bool isFireOn;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Fire_Off");
        onTime = FirePlatform.onTime;
        offTime = FirePlatform.offTime;
        isFireOn = false;
        gameObject.tag = "FirePlatform";
    }

    // Update is called once per frame
    void Update()
    {
        FireAnimation();
    }
    public void FireAnimation()
    {
        /* TODO
         * »ðÑæÅçÉä½ÇÉ«ÊÜÉË
         */
        countTime += Time.deltaTime;
        if(countTime >= offTime && isFireOn == false)
        {
            isFireOn = true;
            animator.Play("Fire_On");
            countTime = 0f;
            gameObject.tag = "Fire";
        }
        if(countTime >= onTime && isFireOn == true)
        {
            isFireOn = false;
            animator.Play("Fire_Off");
            countTime = 0f;
            gameObject.tag = "FirePlatform";
        }
    }
}
