using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour
{
    private int inventoryCapacity = 1;

    // returns true or false if the size of an item is larger than what is available in the inventory
    public bool checkInventory(int size)
    {
        if(size <= inventoryCapacity)
        {
            addToInventory(size);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addToInventory(int size)
    {
        inventoryCapacity -= size;    }

    public void removeFromInventory(int size)
    {
        inventoryCapacity = 1;
    }

}
