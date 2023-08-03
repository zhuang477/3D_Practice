using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Animation : MonoBehaviour
{
    public Animator animator;

    void Update(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("KeepBack_Down")||animator.GetCurrentAnimatorStateInfo(0).IsName("KeepBack_Mid")||animator.GetCurrentAnimatorStateInfo(0).IsName("KeepBack_Up")
        ||animator.GetCurrentAnimatorStateInfo(0).IsName("Addon_Attack 0")){
            animator.SetBool("IsAttacking",true);
        }
        else{
            animator.SetBool("IsAttacking",false);
        }
    }
}
