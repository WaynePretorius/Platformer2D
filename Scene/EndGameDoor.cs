using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDoor : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;

    private float nullTimeSpeed = 0f;
    private float menuWaitTime = 2f;

    private Collider2D myCollider;
    private LevelManager levelManager;
    private void Awake()
    {
        AwakeStartupFunctions();
    }

    private void AwakeStartupFunctions()
    {
        myCollider = GetComponent<Collider2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private IEnumerator LoadMenu()
    {
        Time.timeScale = nullTimeSpeed;
        yield return new WaitForSecondsRealtime(menuWaitTime);
        mainMenuCanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadMenu());
    }
}
