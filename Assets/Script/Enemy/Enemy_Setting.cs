using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the damage dealing.
public class Enemy_Setting : MonoBehaviour
{
    public int head_health;
    public int body_health;
    public int leg_health;
    
    public float basic_damage;
    
    //it is "stanima" instead of "stamina", mind this.
    public int minimum_stanima;
    public int maximum_stanima;
    public float Stanima_RecoveryRate;

    public float stamina;

    //it is in the sword object, use to detect player's sword.
    public Enemy_Clash clash;

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
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
