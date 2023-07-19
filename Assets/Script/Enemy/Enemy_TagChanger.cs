using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TagChanger : MonoBehaviour
{
    public Animator animator;
    private int[] ComboNumbers =new int[10];

    void Start()
    {
        for (int i = 0; i < 10; i++){
            ComboNumbers[i] = i + 1;
        }
        ChangeTagAndChildren(this.gameObject, "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("CombatHead") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintHeadAttack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintHeadAttack 2") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintHeadAttack 3") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintHeadAttack 4")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintBodyAttack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintBodyAttack 2") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintBodyAttack 3") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintBodyAttack 4") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintLegAttack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintLegAttack 2") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintLegAttack 3") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintLegAttack 4")){
            ChangeTagAndChildren(this.gameObject, "Enemy_Attack");
        }else{
            ChangeTagAndChildren(this.gameObject, "Enemy");
        }
    }

    void ChangeTagAndChildren(GameObject obj, string newTag)
    {
        obj.tag = newTag;

        foreach (Transform child in obj.transform)
        {
            ChangeTagAndChildren(child.gameObject, newTag);
        }
    }
}
