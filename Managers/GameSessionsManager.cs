using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionsManager : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] int lifeTaken = 1;

    LevelManager levelManager;

    private void Awake()
    {
        MakeSingleton();
        GetCachedComponents();
    }

    private void GetCachedComponents()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void MakeSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSessionsManager>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayerJustDied()
    {
        if (playerLives > 1)
        {
            TakeaLife();
        }
        else
        {
            RestartGame();
        }
    }

    private void TakeaLife()
    {
        playerLives -= lifeTaken;

        levelManager.RestartScene();
    }

    private void RestartGame()
    {
        levelManager.MainMenu();
        Destroy(gameObject);
    }
}
