using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] COL_LVL;
    public GameObject[] LVL;
    bool Inlvl = false;
    string lvlname;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inlvl = true;
            lvlname = other.name;
        }
    }

    private void Update()
    {
        if (Inlvl == true)
            Debug.Log(lvlname);
    }

}
