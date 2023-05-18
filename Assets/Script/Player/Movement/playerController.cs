using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerModel;

    [HideInInspector]public bool Moveinput =false;
    [HideInInspector]public Vector3 direction;

    public float defaultSpeed =6f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction =new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude >=0.1f){
            controller.Move(direction* defaultSpeed * Time.deltaTime);
            playerModel.transform.position = controller.transform.position;
            Moveinput =true;
        }
        else{
            Moveinput =false;
        }
    }
}
