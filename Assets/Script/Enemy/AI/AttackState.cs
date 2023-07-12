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

    public override void Update()
    {
        base.Update();
        Animator animator = gameobject.GetComponent<Animator>();
        Vector3 playerPosition = gameobject.GetComponent<Enemy_detect>().player_loc_update;
        float PartAttackDetermine = Random.Range(0f, 3f);

        //Calculate the distance between player and pawn.
        float distance = Vector3.Distance(playerPosition, gameobject.transform.position);

        //if the player is fleeing far enough, then the pawn will back to wandering state.
        if(distance> 3.00f){
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
        //if the player stay in the range, then the combat begin.
        else{
            //if the distance is too far,then the pawn will use sprint attack.
            //this part seems can become a independent script, will do it later.
            if(distance >2.00f){
                animator.SetBool("Sprint",true);
                if(PartAttackDetermine <1f){
                    animator.SetBool("AttackHead",true);
                }
                if(PartAttackDetermine >2f){
                    animator.SetBool("AttackLeg",true);
                }else{
                    animator.SetBool("AttackBody",true);
                }
            }
            else{
                animator.SetBool("Sprint",false);
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
