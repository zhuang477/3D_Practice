using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBox : MonoBehaviour
{
    public TagChanger TagManager;
    public GameObject StateIdentifier;
    public Collider[] head;
    public Collider[] body;
    public Collider[] leg;

    public Collider shield;
    public Collider Sword;

    // Update is called once per frame
    void Update(){
        if(StateIdentifier.tag =="Player_Attack"){
            Sword.enabled =true;
        }else{Sword.enabled =false;}
    }
}
