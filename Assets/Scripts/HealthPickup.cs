using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int health = 1;
    private bool collected = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !collected)
        {
            collected = true;
            FindObjectOfType<GameSession>().IncreaseHealth(health);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
