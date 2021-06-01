using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public InventoryItem inventoryItem = null;
    private Image slotImage;

    void Start()
    {
        slotImage = GetComponent<Image>();
    }

    public bool IsActive()
    {
        return inventoryItem != null;
    }

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        UpdateSlotView();
    }

    private void UpdateSlotView()
    {
        slotImage.sprite = inventoryItem.Icon;
    }

    private void RemoveInventoryItem()
    {
        inventoryItem = null;
        slotImage.sprite = null;
    }
}
