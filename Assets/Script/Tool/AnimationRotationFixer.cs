using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRotationFixer : MonoBehaviour
{
    public Animator animator;

    //
    void NoRootMotion(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition") || animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Stance") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male_Sword_Walk")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Sword Sprint")){
            animator.applyRootMotion =false;
        }else{
            animator.applyRootMotion =true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //animator.applyRootMotion =false;
        NoRootMotion();
    }
}
