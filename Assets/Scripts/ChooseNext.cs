using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseNext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseDude()
    {
        PlayerPrefs.SetInt("charNum", 0);
        SceneManager.LoadScene(2);
    }
    public void chooseFrog()
    {
        PlayerPrefs.SetInt("charNum", 1);
        SceneManager.LoadScene(2);
    }
    public void choosePink()
    {
        PlayerPrefs.SetInt("charNum", 2);
        SceneManager.LoadScene(2);
    }
    public void chooseGuy()
    {
        PlayerPrefs.SetInt("charNum", 3);
        SceneManager.LoadScene(2);
    }
}
