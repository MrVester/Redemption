using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPuzzle : MonoBehaviour
{
    int fullElement;
    public static int myElement;

    public GameObject Puzzle;
    public GameObject Panel;
    public GameObject WinPanel;

    void Start()
    {
        fullElement = Puzzle.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        if(fullElement == myElement)
        {
            Panel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}
