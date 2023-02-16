using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinPuzzle : MonoBehaviour
{
    int fullElement;
    public static int myElement;

    public GameObject Puzzle;

    void Start()
    {
        fullElement = Puzzle.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (fullElement == myElement)
        {
            Application.LoadLevel("Game");
        }
    }
    public void LoadMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public static void AddElement()
    {
        myElement++;
    }
}