using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPointer : MonoBehaviour
{
    public GameObject pointerUi;
    public Transform rayPointer;
    [SerializeField]
    private int rayPointerReach = 5;

    private GameObject handPointer;

    void Start()
    {
        handPointer = pointerUi.transform.Find("HandPointer").gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(rayPointer.position, rayPointer.forward, out hit, rayPointerReach);
        Debug.DrawLine(rayPointer.position, rayPointer.position + rayPointer.forward * rayPointerReach, Color.red);

        if (!didHit || !hit.collider.gameObject.tag.Equals("InventoryPickUp"))
        {
            HidePickUpPointer();
        }

        if (didHit)
        {
            GameObject hitGameObject = hit.collider.gameObject;
            if (hitGameObject.tag.Equals("InventoryPickUp"))
            {
                ShowPickUpPointer();
                Debug.Log("Looking at inventory item: " + hit.collider.gameObject.name);
                BroadcastMessage("OnInventoryUserItemInterraction", hitGameObject);
            }
        }
    }

    private void ShowPickUpPointer()
    {
        if (!handPointer.activeSelf)
        {
            handPointer.SetActive(true);
        }
    }

    private void HidePickUpPointer()
    {
        if (handPointer.activeSelf)
        {
            handPointer.SetActive(false);
        }
    }
}
