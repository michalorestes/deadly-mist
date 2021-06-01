using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string itemName;
    public Sprite icon;

    public string ItemName { get => itemName; set => itemName = value; }
    public Sprite Icon { get => icon; set => icon = value; }
}
