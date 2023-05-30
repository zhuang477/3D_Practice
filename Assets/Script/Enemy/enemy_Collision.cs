using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    //it will extend to head,body and leg later.
    public Collider collid;
    private bool IsTheAttackOver_Sword =false;
    private bool IsTheAttackOver_Feet =false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if((other.name =="Sword_" && IsTheAttackOver_Sword ==false) || (other.name =="LeftFoot_" && IsTheAttackOver_Feet ==false)
        || (other.name =="RightFoot_" && IsTheAttackOver_Feet ==false)){
            //Debug.Log("x");
            IsTheAttackOver_Sword =true;
            IsTheAttackOver_Feet =true;
        }
    }

    void OnTriggerExit(Collider other){
        IsTheAttackOver_Sword =false;
        IsTheAttackOver_Feet =false;
    }
}
