using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerAnimation : MonoBehaviour
{
    public playerController playerController_;
    public GameObject playerModel;
    public Animator animator;

    public ComboManager combo;

    public enum AttackPlaceHolder{
        head,
        body,
        leg
    }

    public AttackPlaceHolder AimPart;

    //This is the new input system, this will use into dodge and attack animations.
    //The Dodge, Attack and Block.
    //------------------------------------------------------------------------------------------------//
    public New_PlayerController inputActions;

    private void OnEnable(){
        inputActions.Player.Enable();
    }

    private void OnDisable(){
        inputActions.Player.Disable();
    }

    void Awake(){
        inputActions =new New_PlayerController();
        inputActions.Player.Roll.performed += ctx => Dodge();

        //If detect mouse event, then jump to attack event handler.
        inputActions.Player.Attack.performed += ctx => {
            PerformAttack();};
        
        inputActions.Player.Block.performed += ctx => animator.SetBool("Block",true);
        inputActions.Player.Block.canceled += ctx => animator.SetBool("Block",false);

        inputActions.Player.UpAim.performed += ctx => ChangeAttackPosition_Up();
        inputActions.Player.DownAim.performed += ctx => ChangeAttackPosition_Down();
    }

    void PerformAttack(){
        //New idea, use combo transition to wait for player's decision, if player will not attack, then back to stance.
        //The transition will overlap the whole transition.
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male_Sword_Walk")){
            animator.SetTrigger("Attack 1");
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition")){
            animator.SetTrigger("Attack 2");
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0")){
            animator.SetTrigger("Attack 3");
        }
    }

    //This function is mean to block the input while the animation is playing.
    //If the function is being disabled, then the roll(Dodge) will be influence by input, which you will see a funny in-place roll.
    //
    //if you don't want the animation being affect by input, then add the animation event to the animation(AttackNotDone and AttackDone).
    void AttackOversee(){
        if(!combo.IsAnimationDone){
            animator.SetBool("AnimationIsDone",false);
            inputActions.Player.Disable();
            playerController_.InputActions.Player.Disable();
        }
        if(combo.IsAnimationDone){
            animator.SetBool("AnimationIsDone",true);
            inputActions.Player.Enable();
            playerController_.InputActions.Player.Enable();
        }
    }

    void BeingHitInputLock(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Impact") ||animator.GetCurrentAnimatorStateInfo(0).IsName("Block_Impact")){
            playerController_.InputActions.Player.Disable();
        }
    }

    void Dodge(){
        animator.SetTrigger("Dodge");
    }

    void AimPartManager(){
        if(AimPart ==AttackPlaceHolder.head){
            animator.SetBool("AimHead",true);
            animator.SetBool("AimBody",false);
            animator.SetBool("AimLeg",false);
        }
        if(AimPart ==AttackPlaceHolder.body){
            animator.SetBool("AimHead",false);
            animator.SetBool("AimBody",true);
            animator.SetBool("AimLeg",false);
        }
        if(AimPart ==AttackPlaceHolder.leg){
            animator.SetBool("AimHead",false);
            animator.SetBool("AimBody",false);
            animator.SetBool("AimLeg",true);
        }
    }
    //------------------------------------------------------------------------------------------------//


    // Start is called before the first frame update
    void Start()
    {
        animator =GameObject.Find("Paladin WProp J Nordstrom").GetComponent<Animator>();
        playerController_ =GameObject.FindObjectOfType<playerController>();
    }

    void ChangeAttackPosition_Up(){
        if(!(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0"))){
            if(AimPart !=AttackPlaceHolder.head){
                AimPart -=1;
            }
        }
    }
    void ChangeAttackPosition_Down(){
        if(!(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0"))){
            if(AimPart !=AttackPlaceHolder.leg){
                AimPart +=1;
            }
        }
    }

    void walk_and_run(){
        //face to the situation when the shift is enable while
        //input is not enable YET.
        if(Input.GetKey(KeyCode.LeftShift)){
            if(playerController_.Moveinput ==true){
                playerController_.defaultSpeed =9f;
                animator.SetBool("IsRunning", true);
                //animator.applyRootMotion =false;
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
            if(animator.GetBool("LockTarget") ==true){
                
            }
            if(animator.GetBool("LockTarget") ==false){

            }
        }else{
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        //animation set for lock-on system.
        if(animator.GetBool("IsWalking") ==true){
            if(animator.GetBool("LockTarget") ==true){
                if(Input.GetKeyDown("w")){
                    animator.SetBool("Up_Strafe",true);
                    animator.SetBool("Down_Strafe",false);
                    animator.SetBool("Left_Strafe",false);
                    animator.SetBool("Right_Strafe",false);
                }
                if(Input.GetKeyDown("a")){
                    animator.SetBool("Up_Strafe",false);
                    animator.SetBool("Down_Strafe",false);
                    animator.SetBool("Left_Strafe",true);
                    animator.SetBool("Right_Strafe",false);
                }
                if(Input.GetKeyDown("s")){
                    animator.SetBool("Up_Strafe",false);
                    animator.SetBool("Down_Strafe",true);
                    animator.SetBool("Left_Strafe",false);
                    animator.SetBool("Right_Strafe",false);
                }
                if(Input.GetKeyDown("d")){
                    animator.SetBool("Up_Strafe",false);
                    animator.SetBool("Down_Strafe",false);
                    animator.SetBool("Left_Strafe",false);
                    animator.SetBool("Right_Strafe",true);
                }
            }else{
                animator.SetBool("Up_Strafe",false);
                animator.SetBool("Down_Strafe",false);
                animator.SetBool("Left_Strafe",false);
                animator.SetBool("Right_Strafe",false);
            }
        }
    }

    //Ok, since the changes of speed is more complex to handle, thats why the manager is being build.
    //make every speed change in HERE!
    void SpeedManager(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance") || animator.GetCurrentAnimatorStateInfo(0).IsName("Block_idle")){
            animator.ResetTrigger("Attack 2");
            animator.ResetTrigger("Attack 3");
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male_Sword_Walk") || animator.GetCurrentAnimatorStateInfo(0).IsName("Block_Move")
        || (animator.GetBool("IsWalking") && (animator.GetBool("Up_Strafe") || animator.GetBool("Down_Strafe") ||animator.GetBool("Left_Strafe") ||animator.GetBool("Right_Strafe") ) )){
            playerController_.defaultSpeed =6f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Sprint")){
            playerController_.defaultSpeed =12f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Roll")){
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3")){
            playerController_.defaultSpeed =0f;
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
        SpeedManager();
        AimPartManager();
        AttackOversee();
        BeingHitInputLock();
        //Debug.Log(playerController_.defaultSpeed);
        //CurrentAnimationClip();
    }
}
