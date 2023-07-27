using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCollsionBetween : MonoBehaviour
{
    //this script is for isTrigger setting, I am too lazy to enable the isTrigger one-by-one.

    // Start is called before the first frame update
    void Start()
    {
        Collider[] allColliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in allColliders)
        {
            collider.isTrigger = true;
        }
    }
}
