using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        void Start()
        {

        }

        void LateUpdate()
        {
            this.gameObject.transform.position = target.transform.position;
        }
    }
}

