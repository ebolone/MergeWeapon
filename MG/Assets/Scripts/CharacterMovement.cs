using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;



public class CharacterMovement : MonoBehaviourPunCallbacks
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    float fireRate = 0.3f;
    float timePassed = 0f;

    PhotonView view;


    private CharacterController controller;

    private float playerSpeed = 4.0f;
    private Animator animator;
    private PlayerInput playerInput;

    private float turnSmoothTime = 0.01f;
    float turnSmoothVelocity;

    public Vector3 gg;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        view = GetComponent<PhotonView>();

    }

    void Update()
    { 
        if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (view.IsMine)
        {

            Vector2 joystickInput = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector3 direction = new Vector3(joystickInput.x, 0, joystickInput.y).normalized;

            Vector2 joystickInputt = playerInput.actions["Look"].ReadValue<Vector2>();
            Vector3 joystickLook = new Vector3(joystickInputt.x, 0, joystickInputt.y).normalized;
            if (joystickLook != Vector3.zero)
            {
                gg = joystickLook;
            }

            bool shot = playerInput.actions["Shoot"].triggered;
            bool shot2 = playerInput.actions["Shoot2"].triggered;

            if (shot || shot2)
            {
                direction = Vector3.zero;
                gameObject.transform.forward = gg;
            }
            else if (direction != Vector3.zero)
            {
                //gameObject.transform.forward=direction;
                animator.SetBool("isWalking", true);
            }
            else if (joystickLook != Vector3.zero)
            {
                gameObject.transform.forward = joystickLook;
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            if (direction.magnitude >= 0.1f)
            {

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(direction * playerSpeed * Time.deltaTime);
            }
        }
    }
}