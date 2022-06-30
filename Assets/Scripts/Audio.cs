using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    bool isPlay = true;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3 && isPlay == true)
        {
            audioSource.Pause();
            isPlay = false;
        }
        if(SceneManager.GetActiveScene().buildIndex == 2 && isPlay == false)
        {
            audioSource.Play();
            isPlay = true;
        }
    }
}
