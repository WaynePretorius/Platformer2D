using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private float timeToLoadNextScene = 2f;
    [SerializeField] private float stopTime = 0f;
    [SerializeField] private float continueTime = 1f;

    BoxCollider2D otherCollider;
    LevelManager levelManager;

    private void Awake()
    {
        AwakeStoreCache();
    }

    private void AwakeStoreCache()
    {
        otherCollider = GetComponent<BoxCollider2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private IEnumerator LoadNextScene()
    {
        Time.timeScale = stopTime;
        yield return new WaitForSecondsRealtime(timeToLoadNextScene);
        Time.timeScale = continueTime;
        levelManager.LoadNextLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (otherCollider.IsTouchingLayers(LayerMask.GetMask(Tags.LAYER_PLAYER)))
        {
            StartCoroutine(LoadNextScene());
        }
    }
}
