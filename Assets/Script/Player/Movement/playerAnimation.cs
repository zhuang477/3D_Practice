using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public playerController playerController_;
    public GameObject playerModel;
    public Animator animator;

    public enum AttackPlaceHolder{
        head,
        body,
        leg
    }

    public AttackPlaceHolder AimPart;

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

    void Attack(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(AimPart ==AttackPlaceHolder.head){
                animator.SetTrigger("AttackHead");
            }
            if(AimPart ==AttackPlaceHolder.body){
                animator.SetTrigger("AttackBody");
            }
            if(AimPart ==AttackPlaceHolder.leg){
                animator.SetTrigger("AttackLeg");
            }
        }

    }

    //Ok, since the changes of speed is more complex to handle, thats why the manager is being build.
    //make every speed change in HERE!
    void SpeedManager(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance")){
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3")){
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Roll") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male_Sword_Walk")){
            playerController_.defaultSpeed =6f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Sprint")){
            playerController_.defaultSpeed =12f;
        }
    }

    //The tool that check which animation is playing. Put it to Update() to use if needed.
    void CurrentAnimationClip()
    {
        // Get the current AnimatorClipInfo.
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        if (clipInfo.Length > 0)
        {
            // Print the name of the currently playing clip.
            Debug.Log("Currently playing: " + clipInfo[0].clip.name);
        }
        else
        {
            Debug.Log("No animation is playing.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        walk_and_run();    
        Dodge();
        Attack();
        SpeedManager();
        //CurrentAnimationClip();
    }
}
