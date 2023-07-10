using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_detect : MonoBehaviour
{
    public Collider detect_Range;
    public bool player_detect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" || other.gameObject.tag =="Player_Attack"){
            player_detect =true;}

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player" || other.gameObject.tag =="Player_Attack"){
            player_detect =false;}

    }

}
