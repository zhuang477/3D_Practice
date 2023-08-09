using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the damage dealing.
public class Enemy_Setting : MonoBehaviour
{
    public float basic_damage;
    
    //it is "stanima" instead of "stamina", mind this.
    public int minimum_stanima;
    public int maximum_stanima;
    public float Stanima_RecoveryRate;

    public float stamina;
    public int health;

    //it is in the sword object, use to detect player's sword.
    public Enemy_Clash clash;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if(animator.GetBool("AttackHead") ==true){
            basic_damage *=1.5f;
        }
        if(animator.GetBool("AttackLeg") ==true){
            basic_damage *=0.75f;
        }
        if(clash.gettingClash ==true){
            animator.SetTrigger("GotClash");
        }

        StaminaRecover();
    }
    void StaminaRecover()
    {
        stamina += Stanima_RecoveryRate * Time.deltaTime;
        stamina = Mathf.Clamp(stamina, minimum_stanima, maximum_stanima);
    }
}
