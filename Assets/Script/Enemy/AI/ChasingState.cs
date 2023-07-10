using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    //

    public ChasingState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(!(gameobject.GetComponent<Enemy_detect>().player_detect)){
            statemachine.CurrState =new WanderingState(gameobject, statemachine);
        }else{
            //Waiting for pathfinding code...
        }
    }

    public override void FixedUpdate(){
        base.FixedUpdate();

    }

    public override void Exit(){
        base.Exit();
    }
}
