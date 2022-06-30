using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager2 : MonoBehaviourPun
{
    static GameManager2 instance;
    public Text timeScore;
    public GameObject gameOverUI;
    static int count = 1;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        count = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        int charNum = PlayerPrefs.GetInt("charNum");
        if (charNum == 0)
            PhotonNetwork.Instantiate("MaskDude", new Vector3(1, 1, 0), Quaternion.identity, 0);
        if (charNum == 1)
            PhotonNetwork.Instantiate("NinjaFrog", new Vector3(1, 1, 0), Quaternion.identity, 0);
        if (charNum == 2)
            PhotonNetwork.Instantiate("PinkMan", new Vector3(1, 1, 0), Quaternion.identity, 0);
        if (charNum == 3)
            PhotonNetwork.Instantiate("VirtualGuy", new Vector3(1, 1, 0), Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeScore.text = (Time.timeSinceLevelLoad).ToString("000");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public static void GameOver(bool isDead)
    {
        if (isDead)
        {
            instance.gameOverUI.SetActive(true);
            if(count==1)
            {
                float temp = PlayerPrefs.GetFloat("bestScore");
                if(temp <= Time.timeSinceLevelLoad)
                {
                    PlayerPrefs.SetFloat("bestScore", Time.timeSinceLevelLoad);
                }
                count--;
            }
            //Time.timeScale = 0f;             // ÔÝÍ£ÓÎÏ·
        }
    }
}
