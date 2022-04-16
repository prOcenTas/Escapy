using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;

        if (nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        
        SceneManager.LoadScene(nextLevel);
    }
}
