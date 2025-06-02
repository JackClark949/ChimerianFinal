using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.UI;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.InputSystem.HID;


public class BookShelf : MonoBehaviour
{

    //PLayerInput and actions
    PlayerInput playerInput;
    InputAction PlaceBookAction;
    InputAction RemoveBookAction;
    InputAction OpenPromptAction;
    InputAction ClosePromptAction;
    //Holders where books are stored
    public GameObject BookHolder1;
    public GameObject BookHolder2;
    public GameObject BookHolder3;
    //Books to place and remove
    private Transform RedBook;
    private Transform GreenBook;
    private Transform BlueBook;
    //Add Books and place books from player 
    public GameObject Player;
    //BookShelf Menu
    public GameObject BookShelfPrompt;




    //CurrentlySelectedBook
    private bool RedBookSelected = false;
    private bool GreenBookSelected = false;
    private bool BlueBookSelected = false;
    private BookHolderTrigger bookHolder1Script;
    private BookHolderTrigger2 bookHolder2Script;
    private BookHolderTrigger3 bookHolder3Script;
    private Animation anim;
    private BookPickUp bookPickUpScript;
    public playerMovement playerMovement;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        
        OpenPromptAction = playerInput.actions.FindAction("OpenPrompt");
        ClosePromptAction = playerInput.actions.FindAction("ClosePrompt");
        bookHolder1Script = BookHolder1.GetComponent<BookHolderTrigger>();
        bookHolder2Script = BookHolder2.GetComponent<BookHolderTrigger2>();
        bookHolder3Script = BookHolder3.GetComponent<BookHolderTrigger3>();
       
        BookShelfPrompt.gameObject.SetActive(false);
        anim = GetComponent<Animation>();
        


    }


    //If in any of the bookholders trigger zones and E is pressed menu will appear 
    public void OpenBookShelfPrompt(InputAction.CallbackContext context)
    {
        if (bookHolder1Script.inBookHolderRange1 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.enabled = false;
            

        }



        else if (bookHolder2Script.inBookHolderRange2 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }

        else if (bookHolder3Script.inBookHolderRange3 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

    }
    //For each of the buttons when pressed will check each child attached to Player
    //I used Tags for this so when Button is pressed and player has RedBook and it has it's tag 
    //RedBook is then assigned to child and its redbookselected bool becomes true and the others false
    public void RedBookButton()
    {
        foreach (Transform child in Player.transform)
        {
            if (child.gameObject.CompareTag("RedBook"))
            {
                Debug.Log("RedBook found and selected");
                RedBook = child;
                RedBookSelected = true;
                BlueBookSelected = false;
                GreenBookSelected = false;


                return;
            }

        }
    }

    public void BlueBookButton()
    {
        foreach (Transform child in Player.transform)
        {
            if (child.gameObject.CompareTag("BlueBook"))
            {
                Debug.Log("BlueBook found and selected");
                BlueBook = child;
                BlueBookSelected = true;
                GreenBookSelected = false;
                RedBookSelected = false;

                return;
            }
        }
    }

    public void GreenBookButton()
    {
        foreach (Transform child in Player.transform)
        {
            if (child.gameObject.CompareTag("GreenBook"))
            {
                Debug.Log("GreenBook found and selected");
                GreenBook = child;
                GreenBookSelected = true;
                RedBookSelected = false;
                BlueBookSelected = false;

                return;
            }
        }
    }

    //If in any of bookholder ranges and "ESC" is pressed 
    //Closes bookshelf prompt
    public void CloseBookShelfPrompt(InputAction.CallbackContext context)
    {
        if (bookHolder1Script.inBookHolderRange1 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(false);
        }

        else if (bookHolder2Script.inBookHolderRange2 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(false);
        }

        else if (bookHolder3Script.inBookHolderRange3 == true && context.performed)
        {
            BookShelfPrompt.gameObject.SetActive(false);
        }

    }

    public void PlaceBook()
    {
        //Prevents multiple books being placed on same shelf when a book is placed child count is 1 so checks to see if anything is above that 
        if (BookHolder1.transform.childCount > 1 && BookHolder2.transform.childCount > 1 && BookHolder3.transform.childCount > 1)
        {
            Debug.Log("BookAlreadyPlaced");
            return;
        }

        //Checks if BookHolder has a free space and player is in its trigger zone and checks what book is selected
        //The Local Positions and rotations were to make them fit on the bookholders nicer 
        else if (BookHolder1.transform.childCount == 0 && bookHolder1Script.inBookHolderRange1 == true && RedBookSelected == true)
        {
            RedBook.SetParent(BookHolder1.transform);
            RedBook.gameObject.SetActive(true);

            RedBook.localPosition = new Vector3(0.337f, -0.307f, -0.218f);
            RedBook.localRotation = Quaternion.Euler(0, 3.07f, 0);
            BookShelfPrompt.gameObject.SetActive(false);
            playerMovement.enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DisableBookPickup(RedBook);


        }

        else if (BookHolder1.transform.childCount == 0 && bookHolder1Script.inBookHolderRange1 == true && BlueBookSelected == true)
        {
            BlueBook.SetParent(BookHolder1.transform);
            BlueBook.gameObject.SetActive(true);
            BlueBook.localPosition = new Vector3(0.337f, -0.307f, -0.218f);
            BlueBook.localRotation = Quaternion.Euler(0, 3.07f, 0);
            BookShelfPrompt.gameObject.SetActive(false);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DisableBookPickup(BlueBook);



        }

        else if (BookHolder1.transform.childCount == 0 && bookHolder1Script.inBookHolderRange1 == true && GreenBookSelected == true)
        {
            GreenBook.SetParent(BookHolder1.transform);
            GreenBook.gameObject.SetActive(true);
            GreenBook.localPosition = new Vector3(0.337f, -0.307f, -0.218f);
            GreenBook.localRotation = Quaternion.Euler(0, 3.07f, 0);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BookShelfPrompt.gameObject.SetActive(false);
            DisableBookPickup(GreenBook);




        }

        else if (BookHolder2.transform.childCount == 0 && bookHolder2Script.inBookHolderRange2 == true && RedBookSelected == true)
        {
            RedBook.SetParent(BookHolder2.transform);
            RedBook.gameObject.SetActive(true);
            RedBook.localPosition = new Vector3(0.003f, -0.008f, -0.164f);
            RedBook.localRotation = Quaternion.Euler(2.867f, -2.099f, -279.682f);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BookShelfPrompt.gameObject.SetActive(false);
            DisableBookPickup(RedBook);





        }

        else if (BookHolder2.transform.childCount == 0 && bookHolder2Script.inBookHolderRange2 == true && BlueBookSelected == true)
        {
            BlueBook.SetParent(BookHolder2.transform);
            BlueBook.gameObject.SetActive(true);
            BlueBook.localPosition = new Vector3(0.003f, -0.008f, -0.164f);
            BlueBook.localRotation = Quaternion.Euler(2.867f, -2.099f, -279.682f);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BookShelfPrompt.gameObject.SetActive(false);
            DisableBookPickup(BlueBook);



        }

        else if (BookHolder2.transform.childCount == 0 && bookHolder2Script.inBookHolderRange2 == true && GreenBookSelected == true)
        {
            GreenBook.SetParent(BookHolder2.transform);
            GreenBook.gameObject.SetActive(true);
            GreenBook.localPosition = new Vector3(0.003f, -0.008f, -0.164f);
            GreenBook.localRotation = Quaternion.Euler(2.867f, -2.099f, -279.682f);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BookShelfPrompt.gameObject.SetActive(false);
            DisableBookPickup(GreenBook);


        }

        else if (BookHolder3.transform.childCount == 0 && bookHolder3Script.inBookHolderRange3 == true && RedBookSelected == true)
        {
            RedBook.SetParent(BookHolder3.transform);
            RedBook.gameObject.SetActive(true);
            playerMovement.enabled = true;
            RedBook.transform.localPosition = Vector3.zero;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BookShelfPrompt.gameObject.SetActive(false);
            DisableBookPickup(RedBook);




        }

        else if (BookHolder3.transform.childCount == 0 && bookHolder3Script.inBookHolderRange3 == true && BlueBookSelected == true)
        {
            BlueBook.SetParent(BookHolder3.transform);
            BlueBook.gameObject.SetActive(true);
            BlueBook.transform.localPosition = Vector3.zero;

            BookShelfPrompt.gameObject.SetActive(false);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            DisableBookPickup(BlueBook);
            Cursor.visible = false;
            

        }

        else if (BookHolder3.transform.childCount == 0 && bookHolder3Script.inBookHolderRange3 == true && GreenBookSelected == true)
        {
            GreenBook.SetParent(BookHolder3.transform);
            GreenBook.gameObject.SetActive(true);
            GreenBook.transform.localPosition = Vector3.zero;

            BookShelfPrompt.gameObject.SetActive(false);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DisableBookPickup(GreenBook);






        }
        //If bookholder1 has a child with redbook and 2 with green and 3 with blue 
        //movebookshelf is called
        if (BookHolder1.transform.GetChild(0).gameObject.CompareTag("RedBook") && BookHolder2.transform.GetChild(0).gameObject.CompareTag("GreenBook") && BookHolder3.transform.GetChild(0).gameObject.CompareTag("BlueBook"))
        {
            Debug.Log("SOLVED");
            MoveBookShelf();
        }
    }



    //Whenever a book is placed and player is in bookholder range and bookholder has a book attached to it 
    //Removes it and parents it to the player 
    public void RemoveBook()
    {
        if (bookHolder1Script.inBookHolderRange1 && BookHolder1.transform.childCount == 1)
        {
            RemoveBookFromShelf(BookHolder1.transform.GetChild(0));
            BookShelfPrompt.SetActive(false);
            playerMovement.enabled = true;
            return;
        }

        // Remove from BookHolder2 only if player is in range
        if (bookHolder2Script.inBookHolderRange2 && BookHolder2.transform.childCount == 1)
        {
            RemoveBookFromShelf(BookHolder2.transform.GetChild(0));
            BookShelfPrompt.SetActive(false);
            playerMovement.enabled = true;
            return;
        }

        // Remove from BookHolder3 only if player is in range
        if (bookHolder3Script.inBookHolderRange3 && BookHolder3.transform.childCount == 1)
        {
            RemoveBookFromShelf(BookHolder3.transform.GetChild(0));
            BookShelfPrompt.SetActive(false);
            playerMovement.enabled = true;
            return;
        }

    }
    //Makes sure books can't be picked up when on the shelf 
    //So pickupscript.canbepickedup is made false preventing it from being picked up
    private void DisableBookPickup(Transform book)
    {
        var pickUpScript = book.GetComponent<BookPickUp>();
        if (pickUpScript != null)
        {
            pickUpScript.CanBePickedUp = false;
        }
    }
    //this method when called you can pass through whatever book is on the shelf and then it sets it to the player
    private void RemoveBookFromShelf(Transform book)
    {
        book.SetParent(Player.transform);
        book.gameObject.SetActive(false);

    }


    private void MoveBookShelf()
    {

        Debug.Log("PuzzleSolved");
        //Moves the bookshelf
        anim.Play();

    }

   
}

