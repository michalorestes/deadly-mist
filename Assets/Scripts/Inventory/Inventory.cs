using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject slotHolder;
    private List<GameObject> slots = new List<GameObject>();

    public int maxSlots = 3;

    void Start()
    {
        for (int i = 0; i < maxSlots - 1; i++)
        {
            slots.Add(slotHolder.transform.GetChild(i).gameObject);
        }
    }

    void OnInventoryUserItemInterraction(GameObject gameObject)
    {
        if (InputController.IsContextButtonPressed())
        {
            //Convert pick item to inventory item
            PickUpItem pickUpItem = gameObject.GetComponent<PickUpItem>();
            InventoryItem inventoryItem = new InventoryItem(
                pickUpItem.ItemName,
                pickUpItem.Icon
            );

            //Add Inventory item to inventory
            foreach (GameObject slot in slots)
            {
                if (slot.GetComponent<Slot>().IsActive() == false)
                {
                    slot.GetComponent<Slot>().SetInventoryItem(inventoryItem);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
