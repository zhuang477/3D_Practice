using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_CollideMessage : MonoBehaviour
{

    private bool ReceiveDamage =false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name =="Sword_"){
            if(ReceiveDamage ==false){
                Debug.Log(gameObject.name +" is being hit");
            }
        }
    }

    void OnTriggerExit(Collider other){
        ReceiveDamage =false;
    }
}
