using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject endGameCanvas;

    private int currentSceneIndex;
    private float setTimeBack = 1f;

    private void Awake()
    {
        DeactivateCanvas();
    }

    private void DeactivateCanvas()
    {
        if(!endGameCanvas) { return; }
        endGameCanvas.SetActive(false);
    }

    public void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void MainMenu()
    {
        Time.timeScale = setTimeBack;
        SceneManager.LoadScene(Tags.SCENE_MAIN_MENU);
    }

    public void RestartScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
