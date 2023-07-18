using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TagChanger : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        ChangeTagAndChildren(this.gameObject, "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("CombatHead") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintHeadAttack")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintBodyAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("SprintLegAttack")){
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
