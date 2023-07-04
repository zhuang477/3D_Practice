using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : State
{
    //PawnMoving moving;
    Wandering wandering;

    private float timer;
    private Vector3 direction;

    public float moveSpeed =2f;


    public WanderingState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter(){
        base.Enter();
        //the gameobject is from State.cs, the line
        // gameobject =go;
        //moving = gameobject.GetComponent<PawnMoving>();
        wandering = gameobject.GetComponent<Wandering>();
        timer =0f;
        direction =GetRandomDirection();
    }

    public override void Update(){
        base.Update();
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            direction = GetRandomDirection();
            timer = 0f;
        }

        gameobject.transform.Translate(direction * moveSpeed * Time.deltaTime);
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
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Vector3(x, 0f, z).normalized;
    }
}
