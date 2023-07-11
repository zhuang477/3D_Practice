using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : State
{
    //PawnMoving moving;

    private float timer;
    private Vector3 direction;

    public float moveSpeed =1f;


    public WanderingState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter(){
        base.Enter();
        timer =0f;
        direction =GetRandomDirection();
    }

    public override void Update(){
        base.Update();
        Animator animator = gameobject.GetComponent<Animator>();
        
        //if player is not inside the detect range
        //or if the player is inside the detect range but no line of sight between two.
        //Then the pawn will wandering
        if(!(gameobject.GetComponent<Enemy_detect>().player_detect)
        || (gameobject.GetComponent<Enemy_detect>().player_detect && 
        gameobject.GetComponent<Enemy_detect>().HasLineOfSight() ==false)){
            
            animator.SetBool("Run",false);
            timer += Time.deltaTime;
            if (timer >= 4f)
            {
                direction = GetRandomDirection();
                timer = 0f;
            }
            CharacterController controller = gameobject.GetComponent<CharacterController>();
            Vector3 movement = gameobject.transform.forward * moveSpeed * Time.deltaTime;
            controller.Move(movement);
        }
        else{
            //if player is inside detect range and there is line of sight.
            //Then the pawn is chage into chasing state.
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
    }

    public override void FixedUpdate(){
        base.FixedUpdate();

    }

    public override void Exit(){
        base.Exit();
    }

    private Vector3 GetRandomDirection()
    {
        // Generate a random direction
        //float x = Random.Range(-1f, 1f);
        //float z = 1f;

        //this is making the pawn can turn to different direction (without messing with the axis errors).
        float randomAngle = Random.Range(-360f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f);
        gameobject.transform.rotation = randomRotation;

        //this is making the pawn moving to the relative forward position.
        return new Vector3(0, 0f, 1f).normalized;
    }
}
