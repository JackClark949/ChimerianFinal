using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class blockRotate : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction Rotate;

    public GameObject Prompt;
    private bool blockRotation = false;
    private bool blockRotation2 = false;
    public GameObject PuzzlePiece2;
    public GameObject Drawer;
    private openDrawer OpenDrawerScript;
    MeshRenderer mesh;
    MeshRenderer mesh2;
    



    

    public Quaternion[] rotations;
    public Quaternion[] rotations2;
    private int currentRotation = 0;
    int currentRotation2 = 0;





    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Rotate = playerInput.actions.FindAction("Rotate");
        OpenDrawerScript = Drawer.GetComponent<openDrawer>();
       
        mesh = GetComponentInChildren<MeshRenderer>();
        mesh2 = PuzzlePiece2.GetComponentInChildren<MeshRenderer>();

        
        

        rotations = new Quaternion[]
        {
            Quaternion.Euler(45, 0, 0),
            Quaternion.Euler(60, 0, 0),
            Quaternion.Euler(52, 0, 0)


        };

        rotations2 = new Quaternion[]
        {
            Quaternion.Euler(60, 0, 0),
            Quaternion.Euler(30, 0, 0),
            Quaternion.Euler(80, 0, 0),
        };


    }

   



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Prompt.SetActive(true);

            blockRotation = true;
            blockRotation2 = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        blockRotation = false;
        blockRotation2 = false;
        Prompt.SetActive(false);
    }


    public void RotateBlock(InputAction.CallbackContext context)
    {
        if (blockRotation == true && context.performed)
        {

            currentRotation = (currentRotation + 1) % rotations.Length;
            mesh.transform.rotation = rotations[currentRotation];


            float xRotation = mesh.transform.rotation.eulerAngles.x;
            float xRotation2 = mesh2.transform.rotation.eulerAngles.x;

            if (((Mathf.Abs(xRotation - 45) < 0.1f)) && ((Mathf.Abs(xRotation2 - 30) < 0.1f)))
            {
                OpenDrawerScript.playAnim();
                Debug.Log("Reached both rotations");

                
                
                
                
                  
                
            }












        }

    }

    public void RotateBlock2(InputAction.CallbackContext context)
    {
        if (blockRotation == true && context.performed)
        {
            currentRotation2 = (currentRotation2 + 1) % rotations2.Length;
            mesh2.transform.rotation = rotations2[currentRotation2];
            

            
        }
    }


    

}




