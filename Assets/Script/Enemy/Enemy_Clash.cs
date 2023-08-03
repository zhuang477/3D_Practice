using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_Clash : MonoBehaviour
{
    float startTime =0f;
    float DurationTime =0.1f;
    public bool gettingClash =false;
    public string enemytype;
    public Animator animator;

    //event for attacK AI
    public UnityEvent NotShield =new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gettingClash ==true){
            if (startTime == 0f){
                startTime = Time.time;
            }
            float elapsedTime = Time.time - startTime;

            // Check if the timer has reached the duration
            if (elapsedTime >= DurationTime){
                // Reset the timer and set ReceiveDamage to false
                startTime = 0f;
                gettingClash = false;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name =="SwordCollider"){
            if(gettingClash ==false){
                gettingClash =true;
            }
        }
        if(other.transform.root.name=="Player" &&  
        other.transform.IsChildOf(other.transform.root.GetChild(0).GetChild(0))&& 
        other.gameObject.name !="Shield_"){
            animator.SetBool("Counter",true);
        }
    }
}
