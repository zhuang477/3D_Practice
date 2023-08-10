using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Setting : MonoBehaviour
{
    public int head_health;
    public int body_health;
    public int leg_health;

    public float stamina;

    //it is "stanima" instead of "stamina", mind this.
    public float minimum__stanima;
    public float maximum_stanima;
    public float Stanima_RecoveryRate;

    public float cooldownTime;
    [HideInInspector]public float Refreshtime;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        stamina =maximum_stanima;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaRecover();
    }

    void StaminaRecover(){
        Refreshtime += Time.deltaTime;
        if(animator.GetBool("IsAttacking")){
            stamina -=0.1f;
        }
        if(animator.GetBool("IsRunning")){
            stamina -=0.1f;
        }
        if(animator.GetBool("Dodge")){
            stamina -=20f;
        }

        if(stamina <maximum_stanima 
        && !animator.GetBool("IsAttacking")
        && !animator.GetBool("IsRunning")
        && !animator.GetBool("Dodge")){
            if(Refreshtime >= cooldownTime){
                stamina += Stanima_RecoveryRate;
                Refreshtime =0f;
            }
        }
        
        if (stamina > maximum_stanima)
        {
            stamina = maximum_stanima;
        }
        if(stamina < minimum__stanima)
        {
            stamina = minimum__stanima;
        }
    }
}
