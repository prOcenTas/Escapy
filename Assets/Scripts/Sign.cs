using System;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour
{
    public GameObject signBox;
    public Text signText;
    [SerializeField] public string text;
    
    private void Start()
    {
        signBox.SetActive(false);
        signText.text = text;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Player In Range");
            signBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Left Range");
            signBox.SetActive(false);
        }
    }
}
