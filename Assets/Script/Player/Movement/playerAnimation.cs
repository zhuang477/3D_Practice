using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public playerController playerController;
    public GameObject playerModel;
    public Animator animator;

    [SerializeField] Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        animator =GameObject.Find("Player").GetComponent<Animator>();
        playerController =GameObject.FindObjectOfType<playerController>();
    }

    void walk(){
        if(playerController.Moveinput ==true){
            Quaternion rotation = Quaternion.LookRotation(direction);
            playerModel.transform.rotation = rotation;
            animator.SetBool("IsWalking", true);
        }else{
            animator.SetBool("IsWalking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction =playerController.direction;
        walk();    

    }
}
