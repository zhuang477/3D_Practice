using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public bool IsAnimationDone =true;

    void AttackNotDone(){
        IsAnimationDone =false;
    }

    void AttackDone(){
        IsAnimationDone =true;
    }

    void Update(){
        Debug.Log(IsAnimationDone);
    }
}
