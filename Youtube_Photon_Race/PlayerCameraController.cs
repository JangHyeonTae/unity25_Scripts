using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class PlayerCameraController : MonoBehaviourPun
{

    //[SerializeField] private CinemachineImpulseSource ImpulseSource;
    [SerializeField] public GameObject cam;
    //public void ShakeCamera(Vector3 shakeAmount)
    //{
    //    ImpulseSource.GenerateImpulse(shakeAmount);
    //}
    //shakeAmount = new Vector3(0.2,0.1,0);
    //PlayerCameraController.ShakeCamera(shakeAmount)를 통해 구현하여 접촉시 화면 떨림

    void Start()
    {
        if (photonView.IsMine)
        {
            cam.SetActive(true);
        }
    }

}
