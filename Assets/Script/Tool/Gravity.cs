using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    float g_value =-9.81f;
    Vector3 velocity;
    [SerializeField] CharacterController CC;

    private void Start(){
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CC.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += g_value * Time.deltaTime;
        }

        // Apply gravity
        CC.Move(velocity * Time.deltaTime);
    }
}
