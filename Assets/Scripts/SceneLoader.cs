using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour

{

    GameSession gameSession;

    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        if (currentSceneIndex > 0)
        {
            gameSession.GainLife();
        }
    }

    public void LoadStartScreen()
    {

        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
