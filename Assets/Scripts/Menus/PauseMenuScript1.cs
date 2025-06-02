using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//YouTube Tutorial https://www.youtube.com/watch?v=9dYDBomQpBQ
public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;
    public Weapon weaponScript;
    public Button resumeButton;

    //Renders the pause menu false at start of game
    //finds game objects using tags to reference later
    void Start()
    {
        PauseMenu.SetActive(false);
        weaponScript = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        resumeButton = GameObject.FindGameObjectWithTag("ResumeButton").GetComponent<Button>();
    }

    //If player inputs escape on keyboard, makes boolean true or false
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //Pauses the game by turning timescale to 0 
    //Also disables the weapon script by rendering it false
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        weaponScript.enabled = false;
    }
    //Resumes the game by turning timescale back to 1
    //Also re-enables the weapon script
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        weaponScript.enabled = true;
    }
}
