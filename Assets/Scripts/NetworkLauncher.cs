using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject gobackUI;
    public InputField userName;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PlayerPrefs.SetFloat("bestScore", 0);
    }

    public override void OnConnectedToMaster()
    {
        loginUI.SetActive(true);
    }

    public void PlayButton()
    {
        if(userName.text.Length <= 2 || userName.text.Length >=8)
        {
            loginUI.SetActive(false);
            gobackUI.SetActive(true);
            return;
        }

        PhotonNetwork.NickName = userName.text;
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom("Lobby", roomOptions, default);
        loginUI.SetActive(false);
    }

    public void GoBackButton()
    {
        gobackUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
