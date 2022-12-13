using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootBall.InGameScene.Potal
{
    public class PotalState : MonoBehaviour
    {
        [SerializeField]
        GameObject nextObject;

        public Vector3 NextPosition
        {
            get { return nextObject.transform.position; }
        }

        public GameObject NextObject
        {
            get { return nextObject; }
        }
    }
}