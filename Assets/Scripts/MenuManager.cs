using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadPuzzle()
    {
        SceneManager.LoadScene("Puzzle");
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
