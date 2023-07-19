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
        AttackPart();
        Animator animator = gameobject.GetComponent<Animator>();
        Vector3 playerPosition = gameobject.GetComponent<Enemy_detect>().player_loc_update;

        //Calculate the distance between player and pawn.
        float distance = Vector3.Distance(playerPosition, gameobject.transform.position);

        //if the player is fleeing (but not far enough),then the pawn will chase player.
        if(distance> 7.00f){
            animator.SetBool("CloseCombat",false);
            animator.SetBool("SprintAttack",false);
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
        //if the player stay in the range, then the combat begin.
        //So the pawn's attack direction is depends on the last chasing state frame's direction. With the increased of the attack animation playing,
        //the direction will deviated more.
        else{
            animator.SetBool("CloseCombat",true);
            //using the sprint to quickly approach player between distance 3~10.
            if(distance <7.00f && distance >3.0f){
                animator.SetBool("SprintAttack",true);
                animator.SetInteger("AttackWhere",AttackPart());
            }
            //the pawn and player is close enough to directly start the fight.
            if(distance <3.00f){
                animator.SetBool("SprintAttack",false);
            }
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("AttackSteady")){
            gameobject.transform.LookAt(playerPosition);
        }
    }

    int AttackPart(){
        int PartAttackDetermine =Random.Range(0, 3);
        return PartAttackDetermine;
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
