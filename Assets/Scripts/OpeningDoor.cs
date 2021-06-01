using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    private Animator animator;
    public GameObject doorToOpen;

    void Start()
    {
        animator = doorToOpen.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("In trigger");
        Debug.Log(other.gameObject.tag == "Player");
        Debug.Log(InputController.IsContextButtonPressed());
        if (other.gameObject.tag == "Player" && InputController.IsContextButtonPressed())
        {
            Debug.Log("Changing State");
            bool currentState = animator.GetBool("isOpen");
            animator.SetBool("isOpen", !currentState);
        }
    }
}
