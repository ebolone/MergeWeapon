using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator animator;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if (movement != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            rb.AddForce(movement * speed / Time.deltaTime);
        }        

        if (rb.velocity.magnitude < speed)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
        }
        else if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}

