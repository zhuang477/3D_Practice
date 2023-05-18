using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public playerController playerController;
    public GameObject playerModel;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator =GameObject.Find("Player").GetComponent<Animator>();
        playerController =GameObject.FindObjectOfType<playerController>();
    }

    void walk(){
        if(playerController.Moveinput ==true){
            Quaternion rotation = Quaternion.LookRotation(playerController.moveDirection);
            float rotationSpeed = 15f;
            playerModel.transform.rotation =Quaternion.Slerp(playerModel.transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            animator.SetBool("IsWalking", true);
            animator.applyRootMotion =false;
        }else{
            animator.SetBool("IsWalking", false);
            animator.applyRootMotion =true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        walk();    

    }
}
