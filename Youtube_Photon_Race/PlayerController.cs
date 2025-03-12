using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    [SerializeField] UnityCarAssets.Vehicles.Player.PrometeoCarController playerController;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            playerController.MovePlayer();
        }
    }
}
