using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    public Animator animator;
    //when Player Attack, clash feature enable.
    void Start()
    {
        ChangeTagAndChildren(this.gameObject, "Player");
    }
    void Update(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 2")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3")){
            ChangeTagAndChildren(this.gameObject, "Player_Attack");
        }else{
            ChangeTagAndChildren(this.gameObject, "Player");
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
