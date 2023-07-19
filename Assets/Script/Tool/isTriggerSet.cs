using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTriggerSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MakeChildCollidersTriggers(transform);
    }

    void MakeChildCollidersTriggers(Transform parentTransform)
    {
        // Loop through all child transforms
        foreach (Transform child in parentTransform)
        {
            // Get the Collider component of the child if it exists
            Collider childCollider = child.GetComponent<Collider>();

            // If the child has a Collider, set its isTrigger property to true
            if (childCollider != null)
            {
                childCollider.isTrigger = true;
            }

            // Recursively call the function for the child's children (if any)
            MakeChildCollidersTriggers(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
