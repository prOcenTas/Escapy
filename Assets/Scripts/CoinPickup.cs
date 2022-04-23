using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int points = 10;
    private bool collected = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !collected)
        {
            collected = true;
            FindObjectOfType<GameSession>().IncreaseScore(points);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
