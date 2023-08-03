using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    public Animator animator;
    public ComboManager comboManager;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsAnimationDone",comboManager.IsAnimationDone);
    }
}
