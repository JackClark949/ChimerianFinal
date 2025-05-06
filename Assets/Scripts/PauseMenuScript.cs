using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;
    public Weapon weaponScript;
    public Button resumeButton;

    void Start()
    {
        PauseMenu.SetActive(false);
        weaponScript = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        resumeButton = GameObject.FindGameObjectWithTag("ResumeButton").GetComponent<Button>();
        resumeButton.onClick.AddListener(OnClick);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

            
            

            
        }
    }

    private void OnClick()
    {
        Debug.Log("Button Pressed");
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        weaponScript.enabled = false;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        weaponScript.enabled = true;
        
    }
}
