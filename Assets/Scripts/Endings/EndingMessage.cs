using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMessage : MonoBehaviour
{
    public string message;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MessageBank.message = message;
            SceneManager.LoadScene("Ending");
        }
    }
}
