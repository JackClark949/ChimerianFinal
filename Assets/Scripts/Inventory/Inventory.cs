using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public PlayerInput playerinput;
    InputAction inventoryAction;
    private int currentItemIndex = 0;
    private InputAction slot1Action;
    private InputAction slot2Action;
    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        inventoryAction = playerinput.actions.FindAction("Inventory");

        //slot1Action = playerinput.actions["Slot 1"];
        //slot2Action = playerinput.actions["Slot 2"];

        // Enable the actions
        //slot1Action.Enable();
        //slot2Action.Enable();
    }

    private void Update()
    {
        /*if (slot1Action.triggered) // Slot 1 action
        {
            CycleForward();
        }

        if (slot2Action.triggered) // Slot 2 action
        {
            CycleBackward();
        }*/
    }

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;

        foreach (Item item in items)
        {
            if (item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }

        if (!itemExists)
        {
            items.Add(itemToAdd);
            Debug.Log("New item added: " + itemToAdd.name);
        }
        else
        {
            Debug.Log("Updated item: " + itemToAdd.name + " with new count: " + itemToAdd.count);
        }

        // Debug the list of items to see if the item was added
        Debug.Log("Current Inventory:");
        foreach (var item in items)
        {
            Debug.Log(item.name + " x" + item.count);
        }
    }


    public void RemoveItem(Item itemToRemove)
    {
        foreach (var item in items)
        {
            if (item.name == itemToRemove.name)
            {
                item.count -= itemToRemove.count;
                if (item.count <= 0)
                {
                    items.Remove(itemToRemove);
                }
                break;
            }
        }
        Debug.Log(itemToRemove.count + " " + itemToRemove.name + "removed from inventory.");
    }

    public void CycleForward()
    {
        if (items.Count == 0) return;

        currentItemIndex = (currentItemIndex + 1) % items.Count;
        Debug.Log("Currently Selected Item: " + items[currentItemIndex].name);
    }

    public void CycleBackward()
    {
        if (items.Count == 0) return;

        currentItemIndex = (currentItemIndex - 1 + items.Count) % items.Count;
        Debug.Log("Currently Selected Item: " + items[currentItemIndex].name);
    }
}