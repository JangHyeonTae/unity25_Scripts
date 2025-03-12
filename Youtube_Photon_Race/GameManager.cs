using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Cinemachine.Utility;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance { get;private set; }

    [Header("Debug")]
    [SerializeField] bool autoJoin;
    [SerializeField] byte autoMaxPlayer = 2;

    [Header("Panel")]
    [SerializeField] GameObject connectPanel;
    [SerializeField] GameObject lobbyPanel;
    [SerializeField] GameObject gamePanel;

    [Header("Lobby")]
    [SerializeField] Text quickMatchText;

    [Header("Game")]
    [SerializeField] Transform[] spawnPoints;
    public enum State { None, QuickMatching, QuickMatchDone, RacingStart, RactingDone}
    public State state;

    //actor넘버 밀리는 경우 방지
    public int GetIndex
    {
        get
        {
            for (int i=0; i<PhotonNetwork.PlayerList.Length; i++)
            {
                if (PhotonNetwork.PlayerList[i] == PhotonNetwork.LocalPlayer)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    void Awake()
    {
        Instance = this;
        ShowPanel("ConnectPanel");

        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 15;

        if (autoJoin)
        {
            ConnectClick(null);
        }
    }

    public void ShowPanel(string panelName)
    {
        connectPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gamePanel.SetActive(false);

        if(panelName == connectPanel.name)
        {
            connectPanel.SetActive(true);
        }
        else if(panelName == lobbyPanel.name)
        {
            lobbyPanel.SetActive(true);
        }
        else if(panelName == gamePanel.name)
        {
            gamePanel.SetActive(true);
        }
    }

    public void ConnectClick(InputField nickInput)
    {
        PhotonNetwork.ConnectUsingSettings();

        string nick = nickInput == null ? $"Player{Random.Range(0, 100)}" : nickInput.text;
        PhotonNetwork.NickName = nick;
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        ShowPanel("LobbyPanel");

        if (autoJoin)
        {
            QuickMatchClick();
        }
    }

    public void QuickMatchClick()
    {
        if(state == State.None)
        {
            state = State.QuickMatching;
            quickMatchText.gameObject.SetActive(true);
            PhotonNetwork.JoinRandomOrCreateRoom(null, autoMaxPlayer, MatchmakingMode.FillRoom, null, null,
                $"room{Random.Range(0, 10000)}", new RoomOptions { MaxPlayers = autoMaxPlayer });
        }
        else if(state  == State.QuickMatching)
        {
            state = State.None;
            quickMatchText.gameObject.SetActive(false);
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnJoinedRoom()
    {
        PlayerChanged();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerChanged();

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerChanged();
    }

    void PlayerChanged()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == autoMaxPlayer)
        {
            
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount != PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            return;
        }

        GameStart();
    }

    void GameStart()
    {
        print("Game Start.");
        ShowPanel("GamePanel");
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate("Player", spawnPoints[GetIndex].position, spawnPoints[GetIndex].rotation);
    }

    void Update()
    {
        if(state == State.QuickMatching && PhotonNetwork.InRoom)
        {
            quickMatchText.text = $"{PhotonNetwork.CurrentRoom.PlayerCount} / {PhotonNetwork.CurrentRoom.MaxPlayers}";
        }

    }
}
