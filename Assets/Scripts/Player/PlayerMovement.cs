using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerBody;

    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;

    public float standingHeight = 2f;
    public float crouchingHeight = 1f;

    public Vector3 crouchingBodyScale = new Vector3(0, 0.5f, 0);


    private bool isCrouching = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        ProcessJumping();
        ProcessCrouching();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void ProcessJumping()
    {
        if (Input.GetButton("Jump") && isGrounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ProcessCrouching()
    {
        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            isCrouching = true;
            controller.height = crouchingHeight;
            playerBody.localScale -= crouchingBodyScale;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
            controller.height = standingHeight;
            playerBody.localScale += crouchingBodyScale;
        }
    }

}
