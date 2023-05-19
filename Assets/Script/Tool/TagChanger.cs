using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    //Ok I don't want to change the tag one-by-one so I create this tool to replace the tag when game initalized.
    void Start()
    {
        ChangeTagAndChildren(this.gameObject, "Player");
    }

    void ChangeTagAndChildren(GameObject obj, string newTag)
    {
        obj.tag = newTag;

        foreach (Transform child in obj.transform)
        {
            ChangeTagAndChildren(child.gameObject, newTag);
        }
    }
}
