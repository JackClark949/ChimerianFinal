using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//YouTube Tutorial https://www.youtube.com/watch?v=-GWjA6dixV4
public class MainMenu : MonoBehaviour
{
    //Goes to the next scene in the scene manager
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
