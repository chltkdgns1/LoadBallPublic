using ShootBall.InGameScene.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardListenner : MonoBehaviour
{
    [SerializeField]
    Move movePlayer;
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(movePlayer == null)
        {
            movePlayer = GameObject.Find("BallPlayer").GetComponent<Move>(); 
            
            if(movePlayer == null)
            {
                Debug.LogError("BallPlayer dont exist on Scene");
                return;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movePlayer.MovePlayer(Move.Direction.LEFT);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movePlayer.MovePlayer(Move.Direction.RIGHT);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movePlayer.MovePlayer(Move.Direction.TOP);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movePlayer.MovePlayer(Move.Direction.BOTTOM);
        }
    }
}
