using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rank : MonoBehaviour
{
    public Text bestScore;
    // Start is called before the first frame update
    private void Awake()
    {
        bestScore.text = PlayerPrefs.GetFloat("bestScore").ToString("000");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene(2);
    }
}
