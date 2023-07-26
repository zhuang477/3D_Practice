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
        if(animator.GetBool("KeepBack")){
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
