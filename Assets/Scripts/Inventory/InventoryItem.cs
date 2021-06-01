using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem { 
    private string itemName;
    private Sprite icon;

    public string ItemName { get => itemName; set => itemName = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    public InventoryItem(string itemName, Sprite icon)
    {
        this.ItemName = itemName;
        this.Icon = icon;
    }
}
