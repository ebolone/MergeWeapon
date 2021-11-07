using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private Animator animator;
    private PlayerInput playerInput;
    PhotonView view;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
                animator.SetBool("isWalking", true);
            }

            //ON SCREEN JOYSTICK

            Vector2 joystickInput = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector3 joystickMove = new Vector3(joystickInput.x, 0, joystickInput.y);

            controller.Move(joystickMove * Time.deltaTime * playerSpeed);

            if (joystickMove != Vector3.zero)
            {
                gameObject.transform.forward = joystickMove;
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

        }
    }
}