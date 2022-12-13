using ShootBall.InGameScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShootBall.InGameScene.Player.Move;

namespace ShootBall.Util
{
    public class DirectionObject : MonoBehaviour
    {
        public Direction _dir;
        public float[] _rotationArr = { 180f, 0f, 270f, 90f };
    }
}
