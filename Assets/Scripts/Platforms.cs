using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private Vector3 movement;
    public float speed;
    private GameObject topline;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeSinceLevelLoad < 30f)
            speed = 2;
        else if (Time.timeSinceLevelLoad < 60f)
            speed = 2.5f;
        else if (Time.timeSinceLevelLoad < 90f)
            speed = 3f;
        else if (Time.timeSinceLevelLoad < 120f)
            speed = 3.5f;
        else
            speed = 4.5f;
        movement.y = speed;
        topline = GameObject.Find("TopLine");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;

        if(transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
