using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the damage dealing.
public class Enemy_AttackSetting : MonoBehaviour
{
    public enum AttackPlaceHolder{
        head,
        body,
        leg
    }

    public float basic_damage =40;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if(animator.GetBool("AttackLeg") ==true){
            basic_damage *=0.75f;
        }
    }
}
