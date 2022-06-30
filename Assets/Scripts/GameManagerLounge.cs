using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLounge : MonoBehaviourPunCallbacks
{
    public GameObject startButton;
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
        
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void Rank()
    {
        SceneManager.LoadScene(4);
    }
    public void About()
    {
        SceneManager.LoadScene(5);
    }
}
