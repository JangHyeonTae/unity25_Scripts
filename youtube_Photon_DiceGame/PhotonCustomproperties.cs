using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonCustomproperties : MonoBehaviour
{
    //1�� room����: CustomProperties - ��� player �±� �ޱ�
    //�濡 ���� �� ������ ���� ��(room ����)�� ������ �±׸� �� �� �ִ�.
    //Ű�� ���ڿ��̾�� �ϰ� ���� ������ ����ȭ�� �� �ִ� ���� ���� ����
    //Ű�� �ٸ� ���� ���� �� ����
    //�ڵ� ����ȯ �ȵǹǷ� 0�� 0f����
    //CustomProperties�� �������� SetCutomProperties�� ��� (CustomProperties �ȵ� ��� ����)

    //public override void OnJoinedRoom()
    //{
    //    PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "Ű1", "���ڿ�" }, { "Ű2", 1 } });
    //    print(PhotonNetwork.CurrentRoom.CustomProperties["Ű1"]);
    //}


    //2�� Player����: 

    //public override void OnJoinedRoom()
    //{
    //    PhotonNetwork.PlayerList[0].SetCustomProperties(new Hashtable() { { "Ű1", "���ڿ�" }, { "Ű2", 1 } });
    //    print(PhotonNetwork.PlayerList[0].CustomProperties["Ű1"]);
    //}


    //3. īƮ���̴� �游��� ����
    
    //�� ������ 0�� �ڱ� ��ȣ, �������� ���� 0, ���� �а��� ���� -1, ������ ������ Set����
    //If(S.Master)
    //{
    //    int max = PhotonNetwork.CurrentRoom.MaxPlayers - 1;

    //    PhotonNetwork.CurrentRoom.SetCustomProperties
    //        (new Hashtable
    //        {
    //            {"0", PhotonNetwork.LocalPlayer.ActorNumber }, {"1",0},
    //            {"2", 2 <= max ? 0 :-1}, {"3", 3 <= max ? 0 :-1},
    //            {"4", 4 <= max ? 0 :-1}, {"5", 5 <= max ? 0 :-1},
    //            {"6", 6 <= max ? 0 :-1}, {"7", 7 <= max ? 0 :-1}
    //        }
    //        );
    //}


    //4. �� ��ȯ�� ����ȭ ����
    //īƮ���̴��� ������ȭ����
    //�Ϲ������� �� ��ȯ�� �� ��� Player�� ���� ��ȯ���� �ʴ´� -> �ذ��ϱ����� ����ȯ�� ����ȭ ���� �ʿ�
    //S -> SingleTon 
    //IEnumerator Loading�ؼ� :
    //while(AllhasTag("loadScene")) -> ��� �÷��̾���� loadScene -> key �� ������ �ִٸ� if�� ����
    //if(S.master()) -> �����̶�� SpawnSettin()���� -> ���� ����
    //while(AllhasTag("loadPlayer)) -> ��� �������� loadPlayerŰ Ȯ���� ������ ����

    //public bool AllhasTag(string key)
    //{
    //    for(int i=0; i < PhotonNetwork.PlayerList.Length; i++)
    //    {
    //        if (PhotonNetwork.PlayerList[i].CustomProperties[key] == null)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //IEnumerator Loading()
    //{
    //    while (!S.AllhasTag("loadScene")) yield return null;
    //    if (S.master()) SpawnSetting();
    //    while (!S.AllhasTag("loadPlayer")) yield return null;
    //}


}
