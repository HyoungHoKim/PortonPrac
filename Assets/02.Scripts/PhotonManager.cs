using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private const string gameVersion = "1.0";
    private string playerName;
    private string roomName;
    
    public byte maxPlayers = 20;

    public TMP_InputField playerNameIF;
    public TMP_InputField roomNameIF;


    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;     
    }

    private void Start()
    {
        playerName = PlayerPrefs.GetString("PLAYER_NAME", "Player_" + Random.Range(0, 100).ToString("000"));
        playerNameIF.text = playerName;
        roomNameIF.text = "Room_" + Random.Range(0, 101).ToString("100");

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Already Connected");
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region DEVELOPERS_CALLBACK

    public void OnJoinRoomButtonClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCreateRoomButtonClick()
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = maxPlayers; // 접속 가능 플레이어 수 
        ro.IsOpen = true;           // 접속 가능 여부
        ro.IsVisible = true;        // 룸에 접속했을 때 목록에 표시여부

        PhotonNetwork.CreateRoom(roomNameIF.text, ro);
    }

    public void OnChangedPlayerName()
    {
        playerName = playerNameIF.text;
        PlayerPrefs.SetString("PLAYER_NAME", playerName);

    }

    #endregion

    #region PUN_CALLBACK

    //PUN에 접속했을 때 콜백
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        //PhotonNetwork.JoinRandomRoom();
    }


    //Random Join이 실패했을 때 호출되는 콜백
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        /*
        Debug.Log($"Join Failure {returnCode} / {message}");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = maxPlayers; // 접속 가능 플레이어 수 
        ro.IsOpen = true;           // 접속 가능 여부
        ro.IsVisible = true;        // 룸에 접속했을 때 목록에 표시여부

        PhotonNetwork.CreateRoom("MyRoom", ro);
        */
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Create and Joined Room !!!");

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Level01");
        }
    }

    #endregion
}
