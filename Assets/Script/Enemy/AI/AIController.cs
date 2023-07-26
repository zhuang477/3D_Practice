using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private StateMachine statemachine;

    private void Awake(){
        statemachine =new StateMachine();
        statemachine.CurrState =new WanderingState(gameObject, statemachine);
    }

    // Update is called once per frame
    void Update()
    {
        statemachine.CurrState.Update();
    }

    void FixedUpdate(){
        statemachine.CurrState.FixedUpdate();
    }
}
