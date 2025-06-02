using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PicturePuzzle2 : MonoBehaviour
{
    //PlayerInput
    PlayerInput playerInput;
    InputAction RotateAction;


    private bool inFrameRange = false;

    public int currentRotation = 0;




    private Quaternion[] rotations;



    public GameObject prompt;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        RotateAction = playerInput.actions.FindAction("Rotate");


        rotations = new Quaternion[]
        {
            Quaternion.Euler(0, 0, 0),
            Quaternion.Euler(-90, 0, 0),
            Quaternion.Euler(-30, 0, 0),
            
        };



    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            inFrameRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            inFrameRange = false;
        }
    }

    public void RotatePainting(InputAction.CallbackContext context)
    {
        if (inFrameRange == true && context.performed)
        {
            currentRotation = (currentRotation + 1) % rotations.Length;
            transform.rotation = rotations[currentRotation];

            float XRotation = transform.rotation.eulerAngles.x;
            Debug.Log(currentRotation);

            if (currentRotation == 0)
            {
                Debug.Log("Reached");
                RotateAction.Disable();
                prompt.SetActive(false);
            }
        }


    }
}
