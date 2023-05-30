using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State curState;

    public State CurrState{
        get => curState;
        set{
            if(curState != null)
                curState.Exit();

            curState =value;

            if(curState != null)
                curState.Enter();
        }
    }
}
