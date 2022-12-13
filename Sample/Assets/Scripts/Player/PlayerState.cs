using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootBall.InGameScene.Potal;
using ShootBall.Util;
using static ShootBall.InGameScene.Player.Move;

namespace ShootBall.InGameScene.Player
{
    public class PlayerState : MonoBehaviour
    {
        Move _moveComp;

        GameObject tempPotalOb; // 현재 턴에서 포탈로 이동했을 경우

        private void Awake()
        {
            _moveComp = GetComponent<Move>();
            _moveComp.MoveEndAct = ResetPotal;
        }

        public void OnEnable()
        {
            ResetState();
        }

        private void Start()
        {
     
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _moveComp.StopMove();
            transform.position = _moveComp.SetPosition(transform.position);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckCollision(collision);
        }

        void CheckCollision(Collider2D collision)
        {
            if (collision.CompareTag("OutLine"))        TriggerOutLine(collision);
            else if (collision.CompareTag("EndPoint"))  TriggerEndPoint(collision);
            else if (collision.CompareTag("Potal"))     TriggerPotal(collision);
            else if (collision.CompareTag("Block"))     TriggerBlock();
        }
        
        void TriggerBlock()
        {
            _moveComp.StopMove();
            transform.position = _moveComp.SetPosition(transform.position);
        }

        void TriggerOutLine(Collider2D collision)
        {
            _moveComp.StopMove();
            gameObject.SetActive(false);
        }

        void TriggerEndPoint(Collider2D collision)
        {
            _moveComp.StopMove();
            transform.position = _moveComp.SetPosition(transform.position);
        }

        void TriggerPotal(Collider2D collision)
        {
            if (tempPotalOb == collision.gameObject) return;
            tempPotalOb = collision.GetComponent<PotalState>().NextObject;
            transform.position = collision.GetComponent<PotalState>().NextPosition;
        }

        public void ResetState()
        {
            _moveComp.ResetState();
        }

        public void MovePlayer(Direction dir)
        {
            _moveComp.MovePlayer(dir);
        }

        public void ResetPotal()
        {
            tempPotalOb = null;
        }
    }
}
