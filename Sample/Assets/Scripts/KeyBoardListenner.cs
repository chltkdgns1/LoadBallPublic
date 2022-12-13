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
                Debug.LogError("�÷��̾ �������Դϴ�. �Ѹ��� �÷��̾ �������ּ���. �Ǵ� �ϳ��� ���������� �÷��� ������ּ���!");
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
