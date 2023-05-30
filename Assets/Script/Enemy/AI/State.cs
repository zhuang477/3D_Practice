using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//In case you forget, the state is only the pattern, it means the state needs enter, update and exit to be
//further specified.
public abstract class State 
{
    protected GameObject gameobject;
    protected StateMachine statemachine;

    public State (GameObject go, StateMachine sm){
        gameobject =go;
        statemachine =sm;
    }

    public virtual void Enter(){

    }

    public virtual void Update(){

    }

    public virtual void FixedUpdate(){

    }

    public virtual void Exit(){

    }
}
