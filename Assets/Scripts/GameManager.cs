using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    static GameManager instance;
    public Text timeScore;
    public GameObject gameOverUI;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
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
        timeScore.text = Time.timeSinceLevelLoad.ToString("000");
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene()
        Time.timeScale = 1f;
    }

    public static void GameOver(bool isDead)
    {
        if(isDead)
        {
            instance.gameOverUI.SetActive(true);
            // Time.timeScale = 0f;             // ‘›Õ£”Œœ∑
        }
    }
}
