using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : State
{
    PawnMoving moving;
    Wandering wandering;


    public WanderingState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter(){
        base.Enter();
        //the gameobject is from State.cs, the line
        // gameobject =go;
        moving = gameobject.GetComponent<PawnMoving>();
        wandering = gameobject.GetComponent<Wandering>();

    }

    public override void Update(){
        base.Update();
    }

    public override void FixedUpdate(){
        base.FixedUpdate();
    }

    public override void Exit(){
        base.Exit();
    }
}
