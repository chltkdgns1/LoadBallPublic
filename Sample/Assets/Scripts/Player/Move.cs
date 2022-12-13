using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootBall.InGameScene.Player
{
    public class Move : MonoBehaviour
    {
        public enum Direction
        {
            LEFT = 0,
            RIGHT,
            BOTTOM,
            TOP
        }

        bool IsMove = false;
        bool IsCollision = false;

        [SerializeField]
        private float _speed;

        int[] _dirX = { -1, 1, 0, 0 };
        int[] _dirY = { 0, 0, -1, 1 };

        Direction _dir;

        public Action MoveEndAct {get;set;}

        public Direction Dir
        {
            get { return _dir; }
        }

        public bool IsCollisionPro
        {
            set { IsCollision = value; }
        }

        public void MovePlayer(Direction dir)
        {
            // 방향이 주어지면 해당 방향으로 날아감.
            if (IsMove || dir < Direction.LEFT || dir > Direction.TOP) return;
            IsMove = true;

            _dir = dir;
            
            //StartCoroutine(MovePlayerRoutine(dir));
        }

        private void FixedUpdate()
        {
            if (IsMove)
            {
                if(IsCollision == false)
                {
                    Vector3 vDir = new Vector3(_dirX[(int)_dir], _dirY[(int)_dir]);
                    transform.position += vDir * _speed * Time.fixedDeltaTime;
                }
                else
                {
                    ResetState();
                }
            }
        }

        private void OnEnable()
        {
            ResetState();
        }

        //IEnumerator MovePlayerRoutine(Direction dir)
        //{
        //    while (IsCollision == false)
        //    {
        //        Vector3 vDir = new Vector3(_dirX[(int)dir], _dirY[(int)dir]);
        //        transform.position += vDir * _speed /* * Time.deltaTime*/; 
        //        yield return new WaitForFixedUpdate();
        //    }
        //    ResetState();
        //}

        public void StopMove()
        {
            IsCollision = true;
        }

        public Vector3 SetPosition(Vector3 pos)
        {
            int dirInt = (int)_dir;
            if (dirInt % 2 == 0) // 왼쪽, 아래 좌표값이 감소함
            {
                float xpos = _dir == Direction.LEFT ? SetPositionXYPos(pos.x, false) : pos.x;
                float ypos = _dir == Direction.BOTTOM ? SetPositionXYPos(pos.y, false) : pos.y;
                return new Vector3(xpos, ypos);
            }
            else
            {
                float xpos = _dir == Direction.RIGHT ? SetPositionXYPos(pos.x, true) : pos.x;
                float ypos = _dir == Direction.TOP ? SetPositionXYPos(pos.y, true) : pos.y;
                return new Vector3(xpos, ypos);
            }
        }

        float SetPositionXYPos(float xypos, bool isUp)
        {
            int essenceXypos = (int)xypos;
            float decimalXypos = xypos - (float)essenceXypos;

            bool IsMinus = false;
            if (decimalXypos < 0)
            {
                decimalXypos += 1f;
                IsMinus = true;
            }

            if (isUp) // 해당 좌표가 증가하고 있다면
            {
                if (0 <= decimalXypos && decimalXypos < 0.5f)
                    decimalXypos = IsMinus == true ? -1f : 0f;

                else if (0.5 <= decimalXypos && decimalXypos < 1f)
                    decimalXypos = IsMinus == true ? -0.5f : 0.5f;
            }
            else
            {
                if (0 < decimalXypos && decimalXypos <= 0.5f)
                    decimalXypos = IsMinus == true ? -0.5f : 0.5f;

                else if (0.5 < decimalXypos && decimalXypos <= 1f)
                    decimalXypos = IsMinus == true ? 0 : 1f;
            }
            return decimalXypos + essenceXypos;
        }

        public void ResetState()
        {
            IsCollision = false;
            IsMove = false;
            MoveEndAct?.Invoke();
        }
    }
}
