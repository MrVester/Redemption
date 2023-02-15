using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLightController : MonoBehaviour
{
    public GameObject GlobalLight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalLight.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalLight.SetActive(true);
        }
    }
}
