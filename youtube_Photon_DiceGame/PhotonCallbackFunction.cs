using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonCallbackFunction : MonoBehaviourPunCallbacks
{
    public override void OnConnected()
    {
        //����

        //PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //�������
        //PhotonNetwork.Disconnect();
    }

    public override void OnConnectedToMaster()
    {
        //�����ͼ��� ����
        //Lobby or Room
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedLobby()
    {
        //�κ� ����
        //PhotonNetwork.JoinLobby();
    }

    public override void OnLeftLobby()
    {
        //�κ� ����
        //PhotonNetwork.LeaveLobby();
    }

    public override void OnCreatedRoom()
    {
        //�� �����

        //PhotonNetwork.CreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //�� ����� ����
    }

    public override void OnJoinedRoom()
    {
        //�� ����

        //PhotonNetwork.JoinRoom("room");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ������ ����
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //�� �������� ����
    }

    public override void OnLeftRoom()
    {
        //�� ����

        //PhotonNetwork.LeaveRoom();
    }

    public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        //���� �κ� ����ϰ� ������ PhotonServerSettings -> Lobby statistics Ȱ��ȭ
        //������ �������� �κ���� ������ �� �� ����

        //PhotonNetwork.JoinLobby(new TypedLobby("dduck", LobbyType.Default));
        //for(int i = 0; i < lobbyStatistics.Count; i++)
        //{
        //    LogText.text += lobbyStatistics[i].Name + ", " + lobbyStatistics[i].PlayerCount + "\n";
        //}
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        //�濡 ���� ��, ������ �ٲ� ��

        //PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

    //List<RoomInfo> myList = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //�κ� ���� ��, �� ����Ʈ ������Ʈ ��

        //int roomCount = roomList.Count;
        //for(int i =0; i<roomCount; i++)
        //{
        //    if (!roomList[i].RemovedFromList)
        //    {
        //        if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
        //        else myList[myList.IndexOf(roomList[i])] = roomList[i];
        //    }
        //    else if (myList.IndexOf(roomList[i]) != -1)
        //    {
        //        myList.RemoveAt(myList.IndexOf(roomList[i]));
        //    }
        //}
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        //�濡 ���� ��, �� �±� �����

        //PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable { { "Roomtag", "tag" } });
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        //�濡 ���� ��, �÷��̾� �±� �����

        //PhotonNetwork.PlayerList[0].SetCustomProperties(new Hashtable { { "PlayerTag", "tag" } });
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //�濡 ���� ��, ���ο� �÷��̾ ����
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //�濡 ���� ��, �ٸ� �÷��̾ ����
    }

}
