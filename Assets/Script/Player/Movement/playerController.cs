using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerModel;
    public float defaultSpeed = 6f;

    public float turnSmoothTime =0.1f;
    float turnSmoothVelocity;

    public New_PlayerController InputActions;
    public Vector2 moveInput;

    [HideInInspector]public float horizontal;
    [HideInInspector]public float vertical;
    public Transform cam; // Reference to the main camera

    [HideInInspector] public bool Moveinput = false;
    [HideInInspector] public Vector3 moveDirection;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (moveInput != Vector2.zero){
            Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
            float targetAngle =Mathf.Atan2(direction.x ,direction.z) *Mathf.Rad2Deg +cam.eulerAngles.y;
            float angle =Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation =Quaternion.Euler(0f, angle, 0f);
            moveDirection =Quaternion.Euler(0f, targetAngle, 0f) *Vector3.forward;
            controller.Move(moveDirection.normalized*defaultSpeed*Time.deltaTime);
            Moveinput = true;
        }else{
            Moveinput = false;
        }
    }

    private void Awake()
    {
        InputActions = new New_PlayerController();  // Create new instance of your InputActions
        InputActions.Player.Move.performed += ctx => OnMove(ctx);  // Bind the Move action to OnMove
        InputActions.Player.Move.canceled += ctx => moveInput =Vector2.zero;
    }

    void OnEnable() {
        InputActions.Enable();  // Enable the input actions when the object is enabled
    } 

    void OnDisable() {
        InputActions.Disable();  // Disable the input actions when the object is disabled
    }
    

}