using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    GameSession gameSession;
    Ball ball;
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.LoseLife();

        if (gameSession.GetLives() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            ball.PlaceBallAbovePaddle();
            ball.LockBallToPaddle();
        }
    }
}
