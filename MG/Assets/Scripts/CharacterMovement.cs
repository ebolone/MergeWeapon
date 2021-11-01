using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private Animator animator;
    private PlayerInput playerInput;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    { 
        Vector3 move = Vector3.zero;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetBool("isWalking", true);
        }

        //ON SCREEN JOYSTICK

        Vector2 joystickInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 joystickMove = new Vector3 (joystickInput.x, 0, joystickInput.y);
        move.y = 0;
        controller.Move(joystickMove * Time.deltaTime * playerSpeed);
    }
}