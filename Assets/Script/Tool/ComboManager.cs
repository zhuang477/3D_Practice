using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public bool IsAnimationDone =true;

    public bool TimesUp =false;

    void InputFrameStart(){
        TimesUp =true;
    }

    void InputFrameEnd(){
        TimesUp =false;
    }

    //I just keep these variables in case I needed.
    void AttackNotDone(){
        IsAnimationDone =false;
    }

    void AttackDone(){
        IsAnimationDone =true;
    }

    void Start(){

    }

    void Update(){
        
    }
}
