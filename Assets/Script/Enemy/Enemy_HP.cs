using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public Rigidbody rb;
    private bool ReceiveDamage =false;

    public ColliderBox colliderList;

    float startTime =0f;
    float DurationTime =0.5f;

    // Update is called once per frame
    void Update()
    {
        if(ReceiveDamage ==true){
            if (startTime == 0f){
                startTime = Time.time;
            }
            float elapsedTime = Time.time - startTime;

            // Check if the timer has reached the duration
            if (elapsedTime >= DurationTime){
                // Reset the timer and set ReceiveDamage to false
                startTime = 0f;
                rb.detectCollisions =true;
                ReceiveDamage = false;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name =="Sword_"){
            if(ReceiveDamage ==false){
                //Debug.Log("xx");
                rb.detectCollisions =false;
                ReceiveDamage =true;
            }
        }
    }
}
