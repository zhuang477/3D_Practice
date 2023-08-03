using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger_2 : MonoBehaviour
{
    public Animator animator;
    public string inital_tag;
    public string attack_tag;
    // Start is called before the first frame update
    void Start()
    {
        ChangeTagAndChildren(this.gameObject, inital_tag);
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("IsAttacking")){
            ChangeTagAndChildren(this.gameObject, attack_tag);
        }else{
            ChangeTagAndChildren(this.gameObject, inital_tag);
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
