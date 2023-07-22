using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocRecord : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position =player.position;
    }
}
