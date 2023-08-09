using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasingState : State
{
    //

    public float moveSpeed =5f;
    public ChasingState(GameObject go, StateMachine sm) : base(go, sm){

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
        Seeker seeker =gameobject.GetComponent<Seeker>();
        RichAI rai =gameobject.GetComponent<RichAI>();

        //Calculate the distance between player and pawn.
        float distance = Vector3.Distance(playerPosition, gameobject.transform.position);

        //there seems a problem about raytracing that if using raytracing to determine state
        //then the state will jump back and fourth between wandering and chasing.
        //I will put down this issue now since this is not quite important.

        //if the player is running away and run out of the detect range.
        if(!(gameobject.GetComponent<Enemy_detect>().player_detect)){
            //disable the running animation is in the wandering state.
            statemachine.CurrState =new WanderingState(gameobject, statemachine);

        //if the player is in the detect range.
        }else{
            //Vector3 movement = gameobject.transform.forward * moveSpeed * Time.deltaTime;

            //if the distance is close enough(if the distance is smaller than 7), then the pawn will get into attack state.
            if(distance <7.00f){
                rai.canMove =false;
                animator.SetBool("AttackState",true);
                statemachine.CurrState =new AttackState(gameobject, statemachine);
            }else{
            //if the range is not close enough to attack, then 
            //the pawn will keep chasing player.
                rai.canMove =true;
                seeker.StartPath(gameobject.transform.position,playerPosition);
                animator.SetBool("Run",true);
            }
        }
    }
    public override void FixedUpdate(){
        base.FixedUpdate();

    }

    public override void Exit(){
        base.Exit();
    }
}
