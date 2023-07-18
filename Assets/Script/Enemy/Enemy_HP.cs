using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public int Health;
    public Rigidbody rb;
    private bool ReceiveDamage =false;

    public Enemy_ColliderBox colliderList;

    /*
    void Start(){
        foreach(Collider collider in colliderList.head){
            if (collider.GetComponent<Child_CollideMessage>() == null)
            {
                collider.gameObject.AddComponent<Child_CollideMessage>();
            }
        }
        foreach(Collider collider in colliderList.body){
            if (collider.GetComponent<Child_CollideMessage>() == null)
            {
                collider.gameObject.AddComponent<Child_CollideMessage>();
            }
        }
        foreach(Collider collider in colliderList.leg){
            if (collider.GetComponent<Child_CollideMessage>() == null)
            {
                collider.gameObject.AddComponent<Child_CollideMessage>();
            }
        }
    }*/

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
