using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ColliderBox : MonoBehaviour
{
    public Enemy_TagChanger TagManager;
    public GameObject StateIdentifier;
    public Collider[] head;
    public Collider[] body;
    public Collider[] leg;
    public Collider shield;
    public Collider Sword;
    public Collider[] Feet;

    // Update is called once per frame
    void Update()
    {
        if(StateIdentifier.tag =="Enemy_Attack"){
            Sword.enabled =true;
        }else{Sword.enabled =false;}
    }
}
