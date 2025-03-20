using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    [SerializeField] private Movement1 Movement_;
    private bool isCrouching;


    CharacterController controller;

    [SerializeField]
    float playerSpeed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 direction = moveAction.ReadValue<Vector2>();
        //Vector3 movement = new Vector3(direction.x, 0, direction.y) * playerSpeed * Time.deltaTime;
        //controller.Move(movement);

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = cameraForward * direction.y + cameraRight * direction.x;
        controller.Move(movement * playerSpeed * Time.deltaTime);


        //Sprinting
        var targetSpeed = Movement_.isSprinting ? Movement_.speed * Movement_.multipler : Movement_.speed;
        Movement_.currentSpeed = Mathf.MoveTowards(Movement_.currentSpeed, targetSpeed, Movement_.acceleration * Time.deltaTime);
        controller.Move(direction * Movement_.currentSpeed * Time.deltaTime);


    }

    public void Sprint(InputAction.CallbackContext context)
    {
        Movement_.isSprinting = context.started || context.performed;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        else
        { transform.localScale = new Vector3(1f, 1f, 1f); }

    }


    [System.Serializable]
    public struct Movement1
    {
        public float speed;
        public float multipler;
        public float acceleration;
        [HideInInspector] public bool isSprinting;
        [HideInInspector] public float currentSpeed;
        [HideInInspector] public bool isCrouching;
    }



}

