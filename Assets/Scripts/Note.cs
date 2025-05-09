using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject NoteUI;
    bool toggle;
    
    public playerMovement player;
    public cameraController Camera;
    public Renderer NoteMesh;

   
    public void OpenCloseNote()
    {
        toggle = !toggle;
        if(toggle == false)
        {
            NoteUI.SetActive(false);
            NoteMesh.enabled = true;
            player.enabled = true;
            Camera.enabled = true;

        }
        if(toggle == true)
        {
            NoteUI.SetActive(true);
            NoteMesh.enabled = false;
            player.enabled = false;
            Camera.enabled = false;
        }
    }
}
