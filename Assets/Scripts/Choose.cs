using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public static Choose instance;
    public int charNum;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCharNum(int num)
    {
        charNum = num;
    }
    public int getCharNum()
    {
        return charNum;
    }
}
