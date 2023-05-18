using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerModel;

    public Transform cam; // Reference to the main camera

    [HideInInspector] public bool Moveinput = false;
    [HideInInspector] public Vector3 moveDirection;

    public float defaultSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            // We get the camera's direction, remove any vertical movement and normalize it
            Vector3 cameraForward = cam.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();
            
            // We then get the right vector from the camera's transform
            Vector3 cameraRight = cam.right;

            // We then apply the camera's forward and right vectors to our input
            moveDirection = cameraForward * vertical + cameraRight * horizontal;
            moveDirection.Normalize();
            
            // Apply the movement to the controller
            controller.Move(moveDirection * defaultSpeed * Time.deltaTime);
            playerModel.transform.position = controller.transform.position;
            Moveinput = true;
        }
        else{
            Moveinput = false;
        }
    }
}