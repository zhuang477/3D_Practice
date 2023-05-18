using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public playerController playerController_;
    public GameObject playerModel;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator =GameObject.Find("Player").GetComponent<Animator>();
        playerController_ =GameObject.FindObjectOfType<playerController>();
    }

    void walk_and_run(){
        //face to the situation when the shift is enable while
        //input is not enable YET.
        if(Input.GetKey(KeyCode.LeftShift)){
            if(playerController_.Moveinput ==true){
                playerController_.defaultSpeed =9f;
                animator.SetBool("IsRunning", true);
                animator.applyRootMotion =false;
            }
        }

        if(playerController_.Moveinput ==true){
            //Get the model's rotation face to camera.
            Quaternion rotation = Quaternion.LookRotation(playerController_.moveDirection);
            float rotationSpeed = 10f;
            playerModel.transform.rotation =Quaternion.Slerp(playerModel.transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if (Input.GetKeyDown(KeyCode.LeftShift)){
                playerController_.defaultSpeed =9f;
                animator.SetBool("IsRunning", true);
            }

            //face to the situation when the shift is disable while
            //input is not.
            if (Input.GetKeyUp(KeyCode.LeftShift)){
                animator.SetBool("IsRunning", false);
            }
            //if there is no shift input, then it is a normal walking.
            else{
                animator.SetBool("IsWalking", true);
            }
            animator.applyRootMotion =false;
        }else{
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);

            animator.applyRootMotion =true;
        }
    }

    void Dodge(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Quaternion rotation = Quaternion.LookRotation(playerController_.moveDirection);
            float rotationSpeed = 10f;
            playerModel.transform.rotation =Quaternion.Slerp(playerModel.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            animator.SetTrigger("Dodge");
        }
    }


    // Update is called once per frame
    void Update()
    {
        walk_and_run();    
        Dodge();
    }
}
