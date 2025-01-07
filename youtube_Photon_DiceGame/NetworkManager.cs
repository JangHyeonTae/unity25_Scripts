using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("DisConnectedPanel")]
    public GameObject DisConnectPanel;
    public InputField NicknameInput;

    [Header("RoomPanel")]
    public GameObject RoomPanel;
    public GameObject initGameBtn, rollBtn;
    public Text[] NicknameTexts;
    public GameObject[] arrowImages;
    public Text[] moneyTexts;
    public Text LogText;


    [Header("Board")]
    public DiceController diceController;
    public Transform[] Pos;
    public PlayerScript[] Players;
    

    public int myNum, turn;
    PhotonView PV;
    const int SIZE = 2;
    void Start()
    {
#if(!UNITY_ANDROID)
        Screen.SetResolution(960, 540, false);
#endif

        PV = photonView;
    }

    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = NicknameInput.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);
    }

    void ShowPanel(GameObject CurPanel)
    {
        DisConnectPanel.SetActive(false);
        RoomPanel.SetActive(false);

        CurPanel.SetActive(true);
    }

    bool Master()
    {
        return PhotonNetwork.LocalPlayer.IsMasterClient;
    }

    public override void OnJoinedRoom()
    {
        ShowPanel(RoomPanel);
        if (Master())
        {
            initGameBtn.SetActive(true);
        }
    }

    public void InitGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != 2) return;

        rollBtn.SetActive(true);
        initGameBtn.SetActive(false);
        PV.RPC("InitGameRPC", RpcTarget.AllViaServer);
    }

    [PunRPC]
    public void InitGameRPC()
    {
        Debug.Log("∞‘¿”Ω√¿€");
        for (int i = 0; i < 2; i++)
        {
            NicknameTexts[i].text = PhotonNetwork.PlayerList[i].NickName;

            if (PhotonNetwork.PlayerList[i] == PhotonNetwork.LocalPlayer)
            {
                myNum = i;
            }
        }
    }

    public void Roll()
    {
        PV.RPC("RollRPC", RpcTarget.MasterClient);
    }

    [PunRPC]
    void RollRPC()
    {
        StartCoroutine(RollCo());
    }

    [PunRPC]
    void EndRollRPC(int money0, int money1)
    {
        turn = turn == 0 ? 1 : 0;

        for(int i= 0; i< SIZE; i++)
        {
            arrowImages[i].SetActive(i == turn);
        }

        rollBtn.SetActive(myNum == turn);

        moneyTexts[0].text = money0.ToString();
        moneyTexts[1].text = money1.ToString();

        if(money0 <= 0 || money1 >= 300)
        {
            LogText.text = NicknameTexts[1].text + "¿Ã Ω¬∏Æ «œºÃΩ¿¥œ¥Ÿ";
        }
        else if(money0 >=300 || money0 <= 0)
        {
            LogText.text = NicknameTexts[0].text + "¿Ã Ω¬∏Æ «œºÃΩ¿¥œ¥Ÿ";
        }
    }

    IEnumerator RollCo()
    {
        yield return StartCoroutine(diceController.Roll());
        yield return StartCoroutine(Players[turn].Move(diceController.num));
        yield return new WaitForSeconds(0.2f);

        PV.RPC("EndRollRPC", RpcTarget.AllViaServer, Players[0].money, Players[1].money);
    }
}
