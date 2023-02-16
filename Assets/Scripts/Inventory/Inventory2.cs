using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = true;
    }

    public void Chest()
    {
        if (inventoryOn)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
        else
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }

    }
}
