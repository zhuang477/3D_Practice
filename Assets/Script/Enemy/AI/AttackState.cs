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
        animator.SetFloat("Stanima",setting.stamina);
        animator.SetFloat("Distance",distance);
        animator.SetBool("ShouldAttack",AttackDecision());

        //float desiredDistance = 4.0f;
        //float movementSpeed =0f;
        //Debug.Log(playerPosition);
        
        if(distance >7.0f){
            animator.SetBool("AttackState",false);
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
        //if the distance is smaller or equal than 7
        else{
            //the whole structure is (0-2.5-4)(4-7)
            //0 -2.5 is the counter distance when the player is too close and the pawn must act(in low~mid stanima).
            gameobject.transform.LookAt(playerPosition);

            //if the distance is close enough(<4)
            if(distance <4.0f){
                //look at player
                gameobject.transform.LookAt(playerPosition);

                //if the stanima is low,then try to keep distance with player.
                if(setting.stamina <=30f){
                    //step back!
                    
                    //
                    //if the player act aggressively and the pawn must act.
                    if(distance <=2.5f){
                        //if the stanima is high enough(>=10) to suppress the player.
                        
                        //cost stanima...

                        //if player got hit, then add a attack to suppress the player.
                        //________________________________
                        //see the Enemy_Clash in Weapons and feet.
                        //________________________________

                        //if stanima is lower than 10, then the pawn will dodge instead of counter attack.
                        //the match of stanima is in the animator.
                    }

                    //if the player not aggressively,then keep the distance till stanima cover.
                    //the animator.SetTrigger("KeepDistance"; did this job.
                }
                //if the stanima is medium, then the pawn will try to counterattack: not aggressively, but not run away from player either. 
                if(setting.stamina >30f && setting.stamina <=60f){
                    

                    //if the player tries to attack.
                    if(distance <=2.5f){
                        //suppress the player.
                        

                    }

                    //if the player not aggressively,then keep the distance till stanima cover.

                }
                //if stanima is high, then try to attack the player.
                if(setting.stamina >60f){
                    
                    
                    //close enough to combat.
                    if(distance <=2.5f){
                        //suppress the player.
                        
                    }
                    //the pawn will start to dicide whether approach player.
                    else{
                        //see the animation page.
                        //
                    }
                }
            }
            //if the distance is not close enough(4<x<7)
            //
            else{

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
