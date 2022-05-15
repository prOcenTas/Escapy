using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private AudioSource coinSound;
    void Awake()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        coinSound = GetComponent<AudioSource>();
    }

    public void ProcessDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void IncreaseScore(int add)
    {
        coinSound.Play();
        score += add;
        scoreText.text = score.ToString();
    }

    public void IncreaseHealth(int add)
    {
        playerLives += add;
        livesText.text = playerLives.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
