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
    public Collider[] Feet;

    [HideInInspector]public List<string> headName =new List<string>();
    [HideInInspector]public List<string> bodyName =new List<string>();
    [HideInInspector]public List<string> legName =new List<string>();

    //since collider[] dosen't have Contains().
    void Awake(){

        //head
        foreach (Collider collider in head)
        {
            // Add the name of each collider to the list
            //you can find ChildCollisionDetect in tool.
            collider.isTrigger =true;
            collider.gameObject.AddComponent<ChildCollisionDetect>();
            headName.Add(collider.gameObject.name);
        }

        //body
        foreach (Collider collider in body)
        {
            // Add the name of each collider to the list
            collider.isTrigger =true;
            collider.gameObject.AddComponent<ChildCollisionDetect>();
            bodyName.Add(collider.gameObject.name);
        }

        //leg
        foreach (Collider collider in leg)
        {
            // Add the name of each collider to the list
            collider.isTrigger =true;
            collider.gameObject.AddComponent<ChildCollisionDetect>();
            legName.Add(collider.gameObject.name);
        }
    }
    // Update is called once per frame
    void Update(){
        if(StateIdentifier.tag =="Player_Attack"){
            Sword.enabled =true;
            Feet[0].enabled =true;
            Feet[1].enabled =true;
        }else{
            Sword.enabled =false;
            Feet[0].enabled =false;
            Feet[1].enabled =false;
        }
    }
}
