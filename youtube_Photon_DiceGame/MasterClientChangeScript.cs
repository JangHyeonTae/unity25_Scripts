using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClientChangeScript : MonoBehaviour
{
    //1. master�Լ� ������ �����
    public bool master()
    {
        return PhotonNetwork.LocalPlayer.IsMasterClient;
    }

    //2.
    //������ ����Ҷ� ������ ��� -> ��� ����� master���� �ѱ�� ���� ȥ�� ����� �ٸ� ������� ����
    //���� : ��� ����ȭ �ʿ���� ���常 ���� ����ϸ��
    //void Click()
    //{
    //    PV.RPC("MasterReceiveRPC", RpcTarget.MasterClient);
    //}

    //[PunRPC]
    //void MasterReceiveRPC()
    //{
    //      //������ ���
    //    PV.RPC("OtherReceiveRPC", RpcTarget.Others);
    //}

    //[PunRPC]
    //void OtherReceiveRPC()
    //{

    //}



    //3. JSON�̶�??
    //JSON�� �������� -> Ŭ��������Ʈ�� ���� ����ȭ ������ ���Ŀ� ���� ����



    //4.Ownership change
    //���� �ѱ�� - photonview component����
    //fixed: ������ ���� ������Ʈ���� ������ �ȹٲ�,
    //TakeeOver: ������ ���� ���� ���ް���,
    //Request: ���� ���ο��� �ҟ����� ��û �� �� ������ ���� �� ������

    //TakeOver�ϰ��: 
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        BallPV.RequestOwnership(); //�ڱⰡ �����̵�
    //        BallPV.TransferOwnership(PhotonNetwork.PlayerListOthers[0]); // �ش� �÷��̾ ������ ��
    //    }
    //    if(BallPV.Owner == PhotonNetwork.LocalPlayer)
    //    {
    //        BallPV.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 2, 0, 0));
    //    }
    //}

    //�������̽� ��Ӱ� ����
    //public class MasterClientChangeScript : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    //{
    //    public void OnOwnershipRequest(PhotonView targetView, Player requestinPlayer)
    //    {
    //        print("��û"); //->BallPV.RequestOwnership()
    //    }
    //    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    //    {
    //        print("�Ű���");//->BallPV.TransferOwnership()
    //    }
    //}



    //5. Request�ϰ��:
    //public override void OnJoinedRoom()
    //{
    //    PlayerPV = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).GetPhotonView();
    //}
    
    //PhotonView FindPlayer()
    //{
    //    foreach(var player in GameObject.FindGameObjectsWithTag("Player"))
    //    {
    //        if (player.GetPhotonView().Owner != PhotonNetwork.LocalPlayer) return player.GetPhotonView();
    //    }
    //    return null;
    //}
    //void Update()
    //{
    //    if (Input.GetAxisDown(KeyCode.Alpha1))
    //    {
    //        FindPlayer().RequestOwnership();
    //    }
    //}

    //public class MasterClientChangeScript : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    //{
    //    public void OnOwnershipRequest(PhotonView targetView, Player requestinPlayer)
    //    {
    //        targetView.TransferOwnership(requestingPlayer);
    //    }
    //}

}
