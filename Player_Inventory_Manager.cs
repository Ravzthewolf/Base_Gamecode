using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory_Manager : MonoBehaviour
{
    //Singleton instance of the inventory manager
    public static Player_Inventory_Manager Instance;

    //List of items in the player's inventory
    private List<Item> inventory = new List<Item>();

    //Event for when inventory is updated
    public delegate void OnInventoryUpdated();
    public event OnInventoryUpdated InventoryUpdated;

    // Start is called before the first frame update
    void Start()
    {
        //Ensure only one instance of the inventory manager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Method to add an item to the inventory
    public void AddItem(Item item)
    {
        inventory.Add(item);
        InventoryUpdated?.Invoke(); //Trigger the iventory update event
    }

    //Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        InventoryUpdated?.Invoke(); //Trigger the inventory removal update
    }

    //Method to check if the player has a specific item
    public bool HasItem()
    {
        return inventory.Contains(item);
    }

    //Method to get the player's inventory
    public List<Item> GetInventory()
    {
        return inventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
