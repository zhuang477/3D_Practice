using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerModel;

    public float turnSmoothTime =0.1f;
    float turnSmoothVelocity;

    [HideInInspector]public float horizontal;
    [HideInInspector]public float vertical;

    public Transform cam; // Reference to the main camera

    [HideInInspector] public bool Moveinput = false;
    [HideInInspector] public Vector3 moveDirection;
    

    public float defaultSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(direction.magnitude >= 0.1f){
            float targetAngle =Mathf.Atan2(direction.x ,direction.z) *Mathf.Rad2Deg +cam.eulerAngles.y;
            float angle =Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation =Quaternion.Euler(0f, angle, 0f);
            moveDirection =Quaternion.Euler(0f, targetAngle, 0f) *Vector3.forward;
            controller.Move(moveDirection.normalized*defaultSpeed*Time.deltaTime);
            Moveinput = true;
        }
        else{
            Moveinput = false;
        }
    }
}