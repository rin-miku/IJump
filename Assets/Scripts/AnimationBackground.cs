using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    private Material backgroundMaterial;
    public Vector2 speed;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset = movement;
    }
}
