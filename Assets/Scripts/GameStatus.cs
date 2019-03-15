﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //state variables
    [SerializeField] int currentScore = 0;

    void Start()
    {
        updateScoreText();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        updateScoreText();
    }

    public void addToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void updateScoreText()
    {
        scoreText.text = currentScore.ToString();

    }
}
