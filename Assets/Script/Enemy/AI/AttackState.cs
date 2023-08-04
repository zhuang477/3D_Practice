using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter()
    {
        base.Enter();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Animator animator = gameobject.GetComponent<Animator>();
        Vector3 playerPosition = gameobject.GetComponent<Enemy_detect>().player_loc_update;
        Enemy_Setting setting = gameobject.GetComponent<Enemy_Setting>();
        ColliderBox colliderBox =gameobject.GetComponent<ColliderBox>();

        //Calculate the distance between player and pawn.
        float distance = Vector3.Distance(playerPosition, gameobject.transform.position);

        Vector3 directionToPlayer = playerPosition - gameobject.transform.position;
        animator.SetInteger("AttackWhere",AttackPart());
        animator.SetInteger("Strafe",StrafeDirection());
        animator.SetBool("ShouldAttack",AttackDecision());
        animator.SetInteger("Stanima",setting.stamina);

        //float desiredDistance = 4.0f;
        //float movementSpeed =0f;
        //Debug.Log(playerPosition);
        
        if(distance >7.0f){
            animator.SetBool("CloseCombat",false);
            animator.SetBool("GetClose",false);
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
        //if the distance is smaller or equal than 7
        else{
            //so there is a two-layer:
            //(0 - 2.5 -4), when the distance is smaller than 2.5, then there is close combat.
            //when the distance is between 2.5 -4, then the pawn will try to approach player.

            //if the distance is close enough(<4)
            if(distance <4.0f){
                animator.SetBool("CloseDistance",true);
                animator.SetBool("GetClose",false);
                //look at player
                gameobject.transform.LookAt(playerPosition);

                //if the stanima is low,then try to keep distance with player.
                if(setting.stamina <=30f){
                    //step back!
                    animator.SetTrigger("KeepDistance");
                    //
                    //if the player act aggressively and the pawn must act.
                    if(distance <=2.5f){
                        //if the stanima is high enough(>=15) to suppress the player.
                        animator.SetTrigger("KeepBack");
                        //cost stanima...

                        //if player got hit, then add a attack to suppress the player.
                        //________________________________
                        //see the Enemy_Clash in Weapons and feet.
                        //________________________________

                        //if stanima is lower than 15, then the pawn will dodge instead of counter attack.
                        //the match of stanima is in the animator.
                    }

                    //if the player not aggressively,then keep the distance till stanima cover.
                    //the animator.SetTrigger("KeepDistance"; did this job.
                }
                //if the stanima is medium, then the pawn will try to counterattack: not aggressively, but not run away from player either. 
                if(setting.stamina >30f && setting.stamina <=60f){
                    animator.SetTrigger("WaitForCounter");

                    //if the player tries to attack.
                    if(distance <=2.5f){
                        //suppress the player.
                        animator.SetTrigger("KeepBack");

                    }

                    //if the player not aggressively,then keep the distance till stanima cover.

                }
                //if stanima is high, then try to attack the player.
                if(setting.stamina >60f){
                    animator.SetTrigger("Combat");
                    
                    //close enough to combat.
                    if(distance <=2.5f){
                        //suppress the player.
                        animator.SetTrigger("KeepBack");
                    }
                    //the pawn will start to dicide whether approach player.
                    else{
                        //see the animation page.
                        //
                    }
                }
            }
            //if the distance is not close enough(4<x<7)
            //this is the layer (4 -x- 7), the whole structure is (0 -2.5 -4)(4-7)
            else{
                gameobject.transform.LookAt(playerPosition);
                animator.SetBool("Counter",false);
                animator.SetBool("CloseDistance",false);
                //different stanima have different movements.
                if(setting.stamina <=30f){

                }
                if(setting.stamina >30f && setting.stamina <=60f){

                }
                if(setting.stamina >60f){
                    //animator.SetBool("GetClose",true);
                }
            }
        }
        Debug.Log(distance);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    int AttackPart(){
        int PartAttackDetermine =Random.Range(0, 3);
        return PartAttackDetermine;
    }
    int StrafeDirection(){
        int StrafeDetermine =Random.Range(0, 2);
        return StrafeDetermine;
    }

    bool AttackDecision(){
        int AttackDetermine =Random.Range(0, 2);
        if(AttackDetermine ==0){
            return true;
        }
        else{
            return false;
        }
    }
}
