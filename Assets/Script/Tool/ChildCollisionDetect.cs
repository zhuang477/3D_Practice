using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChildCollisionDetect : MonoBehaviour
{
    public UnityEvent<string> collisionHappened =new UnityEvent<string>();

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name =="EnemyWeapon" || other.gameObject.name =="EnemyFoot"){
            collisionHappened.Invoke(gameObject.name);
        }
    }
}
