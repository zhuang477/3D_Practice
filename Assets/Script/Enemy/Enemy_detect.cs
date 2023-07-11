using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_detect : MonoBehaviour
{
    public Collider detect_Range;
    public bool player_detect;
    public Vector3 player_loc_update;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" || other.gameObject.tag =="Player_Attack"){
            player_detect =true;}

    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag =="Player" || other.gameObject.tag =="Player_Attack"){
            player_loc_update =other.transform.position;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player" || other.gameObject.tag =="Player_Attack"){
            player_detect =false;}

    }

    public bool HasLineOfSight(){
        RaycastHit hit;
        Vector3 direction_between = player_loc_update -gameObject.transform.position;

        if(Physics.Raycast(gameObject.transform.position,direction_between, out hit)){
             if (hit.collider.tag =="Player" ||hit.collider.tag =="Player_Attack"){
                return true;
             }
        }
        return false;
    }
}
