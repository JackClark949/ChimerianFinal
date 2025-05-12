using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[System.Serializable]

public class BookHolder
{
    public GameObject bookHolder;
    public string desiredBookTag;
    public GameObject currentlyPlacedBook;
    public bool isCorrectlyPlaced;
}


public class BookShelf : MonoBehaviour
{
    public List<BookHolder> bookHolders = new List<BookHolder>();

    PlayerInput playerInput;
    InputAction PlaceBookAction;
    InputAction RemoveBookAction;

    public GameObject BookHolder1;
    public GameObject BookHolder2;
    public GameObject BookHolder3;
    public GameObject Player;
    
    private bool InBookShelfRange;
    private BookHolderTrigger bookHolder1Script;
    private BookHolderTrigger2 bookHolder2Script;
    private BookHolderTrigger3 bookHolder3Script;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PlaceBookAction = playerInput.actions.FindAction("PlaceBook");
        RemoveBookAction = playerInput.actions.FindAction("RemoveBook");
        bookHolder1Script = BookHolder1.GetComponent<BookHolderTrigger>();
        bookHolder2Script = BookHolder2.GetComponent<BookHolderTrigger2>();
        bookHolder3Script = BookHolder3.GetComponent<BookHolderTrigger3>();
        anim = GetComponent<Animation>();



    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            InBookShelfRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            InBookShelfRange = false;
        }
    }

    public void PlaceBook(InputAction.CallbackContext context)
    {
        Transform currentBook = null;

        for (int i = 0; i < Player.transform.childCount; i++)
        {
            Transform child = Player.transform.GetChild(i);

            if (child.CompareTag("RedBook") || child.CompareTag("GreenBook") || child.CompareTag("BlueBook"))
            {
                currentBook = child;
                break;
            }
        }

        if (context.performed && currentBook != null)
        {
            if (bookHolder1Script.inBookHolderRange1)
            {
                currentBook.SetParent(BookHolder1.transform);
                currentBook.localPosition = Vector3.zero; 
                currentBook.gameObject.SetActive(true);

                var pickUpScript = currentBook.GetComponent<BookPickUp>();
                if (pickUpScript != null)
                {
                    pickUpScript.CanBePickedUp = false;
                }
            }

            else if (bookHolder2Script.inBookHolderRange2)
            {
                currentBook.SetParent(BookHolder2.transform);
                currentBook.localPosition = Vector3.zero; 
                currentBook.gameObject.SetActive(true);

                var pickUpScript = currentBook.GetComponent<BookPickUp>();
                if (pickUpScript != null)
                {
                    pickUpScript.CanBePickedUp = false;
                }
            }

            else if (bookHolder3Script.inBookHolderRange3)
            {
                currentBook.SetParent(BookHolder3.transform);
                currentBook.localPosition = Vector3.zero; 
                currentBook.gameObject.SetActive(true);
                var pickUpScript = currentBook.GetComponent<BookPickUp>();
                if (pickUpScript != null)
                {
                    pickUpScript.CanBePickedUp = false;
                }
            }

            MoveBookShelf();
        }

       
    }

    public void RemoveBook(InputAction.CallbackContext context)
    {
        Transform currentlyPlacedBook = null;

        if (bookHolder1Script.inBookHolderRange1 && context.performed)
        {
            currentlyPlacedBook = BookHolder1.transform.GetChild(0);
            currentlyPlacedBook.SetParent(Player.transform);



        }

        else if (bookHolder2Script.inBookHolderRange2 && context.performed)
        {
            currentlyPlacedBook = BookHolder2.transform.GetChild(0);
            currentlyPlacedBook.SetParent(Player.transform);
        }

        else if (bookHolder3Script.inBookHolderRange3 && context.performed)
        {
            currentlyPlacedBook = BookHolder3.transform.GetChild(0);
            currentlyPlacedBook.SetParent(Player.transform);
        }
        

        
    }

    private void MoveBookShelf()
    {
        bool RedTrue = false;
        bool BlueTrue = false;
        bool GreenTrue = false;

        if (BookHolder1.transform.childCount > 0)
        {
            Transform book = BookHolder1.transform.GetChild(0);
            if (book.CompareTag("RedBook"))
            {
                RedTrue = true;
            }
        }
        if (BookHolder2.transform.childCount > 0)
        {
            Transform book = BookHolder2.transform.GetChild(0);
            if (book.CompareTag("GreenBook"))
            {
                GreenTrue = true;
            }
        }

        if (BookHolder3.transform.childCount > 0)
        {
            Transform book = BookHolder3.transform.GetChild(0);
            if (book.CompareTag("BlueBook"))
            {
                BlueTrue = true;
            }
        }

        if(RedTrue == true && BlueTrue == true && GreenTrue == true)
        {
            Debug.Log("PuzzleSolved");
            BookHolder1.transform.GetChild(0).gameObject.SetActive(false);
            BookHolder2.transform.GetChild(0).gameObject.SetActive(false);
            BookHolder3.transform.GetChild(0).gameObject.SetActive(false);

            anim.Play();
        }
    }
}
