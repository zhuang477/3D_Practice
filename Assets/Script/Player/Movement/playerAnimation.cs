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

    private int comboCounter =0;
    private float lastComboTime =0f;
    private float comboResetTime =1f;
    

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
    }

    void PerformAttack(){
        //New idea, use combo transition to wait for player's decision, if player will not attack, then back to stance.
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance")){
            animator.SetTrigger("Attack 1");
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition")){
            animator.SetTrigger("Attack 2");
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0")){
            animator.SetTrigger("Attack 3");
        }
    }


    void AttackOversee(){
        if(!combo.IsAnimationDone){
            animator.SetBool("AnimationIsDone",false);
            inputActions.Player.Attack.Disable();
        }
        if(combo.IsAnimationDone){
            animator.SetBool("AnimationIsDone",true);
            inputActions.Player.Attack.Enable();
        }
    }



    void Dodge(){
        /**
        if(Input.GetKeyDown(KeyCode.Space)){
            Quaternion rotation = Quaternion.LookRotation(playerController_.moveDirection);
            float rotationSpeed = 10f;
            playerModel.transform.rotation =Quaternion.Slerp(playerModel.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            animator.SetTrigger("Dodge");
        }**/
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

    void InputLocker(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Roll")){
            playerController_.InputActions.Player.Disable();
        }else{
            playerController_.InputActions.Player.Enable();
        }
    }


    //------------------------------------------------------------------------------------------------//


    // Start is called before the first frame update
    void Start()
    {
        animator =GameObject.Find("Paladin WProp J Nordstrom").GetComponent<Animator>();
        playerController_ =GameObject.FindObjectOfType<playerController>();
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
        }else{
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
    }

    //Ok, since the changes of speed is more complex to handle, thats why the manager is being build.
    //make every speed change in HERE!
    void SpeedManager(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance")){
            animator.ResetTrigger("Attack 2");
            animator.ResetTrigger("Attack 3");
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male_Sword_Walk")){

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
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 4") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 5") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 6")){
            playerController_.defaultSpeed =0f;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 7") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 8") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 9")){
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
        InputLocker();
        //ResetTimer();
        AttackOversee();
        //Debug.Log(playerController_.defaultSpeed);
        //CurrentAnimationClip();
    }
}
