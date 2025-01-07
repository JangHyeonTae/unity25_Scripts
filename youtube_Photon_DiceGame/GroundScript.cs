using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GroundScript : MonoBehaviourPun
{
    public enum GroundType
    {
        GROUND,
        GOLDKEY,
        START
    };
    public GroundType groundType;
    public int price, owner;

    PhotonView PV;
    TextMesh priceText;
    GameObject[] cubes;
    int[] goldKeyMoneys = new int[6] { -20, -10, 0, 10, 20, 30 };

    void Start()
    {
        PV = photonView;
        if (groundType == GroundType.GROUND)
        {
            priceText = GetComponentInChildren<TextMesh>();
            cubes = new GameObject[2] { transform.GetChild(1).gameObject, transform.GetChild(2).gameObject };
        }
    }

    [PunRPC]
    void AddPriceRPC()
    {
        price += 10;
        priceText.text = price.ToString();
    }


    public void TypeSwitch(PlayerScript curPlayer, PlayerScript otherPlayer)
    {
        if(groundType == GroundType.GROUND)
        {
            GroundOwner(curPlayer, otherPlayer);
            PV.RPC("AddPriceRPC", RpcTarget.AllViaServer);
        }
        else if(groundType == GroundType.GOLDKEY)
        {
            int addMoney = goldKeyMoneys[Random.Range(0, goldKeyMoneys.Length)];
            curPlayer.money += addMoney;
            print(curPlayer + "�� " + addMoney + "��ŭ �������ϴ�");
        }
    }

    void GroundOwner(PlayerScript curPlayer, PlayerScript otherPlayer)
    {
        int myNum = curPlayer.myNum;

        if(owner == -1)
        {
            curPlayer.money -= price;
            print(myNum + "��" + price + "�Ҿ����ϴ�");

            owner = myNum;
            PV.RPC("CubeRPC", RpcTarget.AllViaServer, myNum);
        }
        else if(owner != myNum)
        {
            curPlayer.money -= price;
            otherPlayer.money += price;
            print(myNum + "��" + price + "�� �Ҿ���");
            print(otherPlayer.myNum + "��" + price + "��ŭ �����");
        }
    }
    [PunRPC]
    void CubeRPC(int myNum)
    {
        cubes[myNum].SetActive(true);
    }

}
