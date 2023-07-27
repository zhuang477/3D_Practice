using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player_BeingHit : MonoBehaviour
{
    public Rigidbody rb;
    private bool ReceiveDamage =false;
    public ColliderBox colliderbox;
    public Animator animator;
    public LockOn lockon;
    float startTime =0f;
    //maybe longer?
    float DurationTime =0.8f;

    void Start(){
        // Get all the ChildCollisionDetect scripts in the children of this GameObject
        ChildCollisionDetect[] childScripts = GetComponentsInChildren<ChildCollisionDetect>();

        // Subscribe the HandleChildCollision method to the onCollisionEvent of each child script
        foreach (ChildCollisionDetect childScript in childScripts)
        {
            childScript.collisionHappened.AddListener(HandleChildCollision);
        }
    }
    
    void HandleChildCollision(string childName){
        if(ReceiveDamage ==false){

            if(colliderbox.shield.name ==childName){
                //Debug.Log("Block");
                if(animator.GetBool("LockTarget") ==false){
                    lockon.gameObject.transform.LookAt(lockon.currentlyLockedTarget);
                }
                animator.SetTrigger("Block_Hit");

            }
            else if(colliderbox.headName.Contains(childName)){
                //Debug.Log("head");
                if(animator.GetBool("LockTarget") ==false){
                    lockon.gameObject.transform.LookAt(lockon.currentlyLockedTarget);
                }
                animator.SetTrigger("GetHit");
            }
            else if(colliderbox.bodyName.Contains(childName)){
                //Debug.Log("body");
                if(animator.GetBool("LockTarget") ==false){
                    lockon.gameObject.transform.LookAt(lockon.currentlyLockedTarget);
                }
                animator.SetTrigger("GetHit");
            }
            else if(colliderbox.legName.Contains(childName)){
                //Debug.Log("leg");
                if(animator.GetBool("LockTarget") ==false){
                    lockon.gameObject.transform.LookAt(lockon.currentlyLockedTarget);
                }
                animator.SetTrigger("GetHit");
            }

            rb.detectCollisions =false;
            ReceiveDamage =true;
        }
    }

    void Update(){
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
}
