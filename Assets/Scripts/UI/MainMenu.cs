using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //                    Start Game

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Main!");
    }

    //                    Closes Game

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    //                 Goes to next level

    public void NexLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //                  Opens Main Menu

    public void MMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ResStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
