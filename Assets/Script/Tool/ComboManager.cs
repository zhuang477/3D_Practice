using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public bool IsAnimationDone =true;

    public bool IsInputAllowed =false;

    void InputFrameStart(){
        IsInputAllowed =true;
    }

    void InputFrameEnd(){
        IsInputAllowed =false;
    }

    //I just keep these variables in case I needed.
    void AttackNotDone(){
        IsAnimationDone =false;
    }

    void AttackDone(){
        IsAnimationDone =true;
    }

    void Update(){
        //Debug.Log(IsAnimationDone);
    }
}
