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

        if (Input.anyKeyDown == false) return;

        Debug.Log("KeyDown");

        if(movePlayer == null)
        {
            var player = GameObject.Find("BallPlayer");

            if (player == null)
            {
                Debug.LogError("BallPlayer dont exist on Scene");
                return;
            }

            movePlayer = player.GetComponent<Move>(); 
            
            if(movePlayer == null)
            {
                Debug.LogError("BallPlayer Move Component dont exist on Scene");
                return;
            }
        }
        else
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if(players.Length > 1)
            {
                Debug.LogError("플레이어가 여러명입니다. 한명의 플레이어만 선정해주세요. 또는 하나의 스테이지만 올려서 만들어주세요!");
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
