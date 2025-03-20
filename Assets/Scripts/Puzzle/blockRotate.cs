using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class blockRotate : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction Rotate;
    openDrawer openDrawer;
    //public GameObject openDrawerr;
    private bool blockRotation = false;
    blockRotate2 blockrotate2;
    MeshRenderer mesh;



    //public GameObject rotatePiece2;

    public Quaternion[] rotations;
   
    private int currentRotation = 0;
    





    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Rotate = playerInput.actions.FindAction("Rotate");
        blockrotate2 = GetComponent<blockRotate2>();
        //openDrawer = openDrawerr.GetComponent<openDrawer>();
        mesh = GetComponentInChildren<MeshRenderer>();


        rotations = new Quaternion[]
        {
            Quaternion.Euler(45, 0, 0),
            Quaternion.Euler(75, 0, 0),
            Quaternion.Euler(52, 0, 0)


        };

       

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blockRotation = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        blockRotation = false;

    }


    public void RotateBlock(InputAction.CallbackContext context)
    {
        if (blockRotation == true && context.performed)
        {

            currentRotation = (currentRotation + 1) % rotations.Length;
            gameObject.transform.rotation = rotations[currentRotation];
            Debug.Log("Rotated");



            //float xRotation = gameObject.transform.rotation.eulerAngles.x;
            float xRotation = mesh.transform.rotation.eulerAngles.x;
            float xRotation2 = blockrotate2.mesh.transform.rotation.eulerAngles.x;
            

            if (xRotation == 75 && xRotation2 == 80)
            {
                Debug.Log("Reached both rotations");
            }
            




        }

        
        

        






    }




}


