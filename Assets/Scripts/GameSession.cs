using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLives = 3;


    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        UpdateScoreText();
        UpdateLivesText();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        UpdateScoreText();
        UpdateLivesText();

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();

    }

    public void UpdateLivesText()
    {
        livesText.text = currentLives.ToString();

    }
    
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public int GetLives()
    {
        return currentLives;
    }

    public void LoseLife()
    {
        currentLives--;
    }

    public void GainLife()
    {
        currentLives++;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
