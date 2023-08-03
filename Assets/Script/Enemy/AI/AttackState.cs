using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(GameObject go, StateMachine sm) : base(go, sm){

    }

    public override void Enter()
    {
        base.Enter();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Animator animator = gameobject.GetComponent<Animator>();
        Vector3 playerPosition = gameobject.GetComponent<Enemy_detect>().player_loc_update;
        Enemy_Setting setting = gameobject.GetComponent<Enemy_Setting>();
        ColliderBox colliderBox =gameobject.GetComponent<ColliderBox>();

        //
        Enemy_Clash addon_Attack =gameobject.GetComponentInChildren<Enemy_Clash>();
        addon_Attack.NotShield.AddListener(Addon_Attack_Animation);

        //Calculate the distance between player and pawn.
        float distance = Vector3.Distance(playerPosition, gameobject.transform.position);

        Vector3 directionToPlayer = playerPosition - gameobject.transform.position;
        animator.SetInteger("AttackWhere",AttackPart());

        //float desiredDistance = 4.0f;
        //float movementSpeed =0f;
        //Debug.Log(playerPosition);
        
        if(distance >7.0f){
            animator.SetBool("CloseCombat",false);
            animator.SetBool("GetClose",false);
            statemachine.CurrState =new ChasingState(gameobject, statemachine);
        }
        //if the distance is smaller or equal than 7
        else{
            //if the distance is close enough
            if(distance <4.0f){

                animator.SetBool("GetClose",false);
                //look at player
                gameobject.transform.LookAt(playerPosition);

                //if the stanima is low,then try to keep distance with player.
                if(setting.stamina <=30f){
                    //step back!
                    animator.SetTrigger("KeepDistance");
                    //
                    //if the player act aggressively and the pawn must act.
                    if(distance <=2f){
                        animator.SetTrigger("KeepBack");
                        //cost stanima...

                        //if player got hit, then add a attack to suppress the player.
                        //________________________________
                        //see the Addon_Attack_Animation(), I use an event so the addon attack implement is not in here.
                        //________________________________

                    }

                    //if the player not aggressively,then keep the distance till stanima cover.
                    
                }
                //if the stanima is medium, then the pawn will try to counterattack: not aggressively, but not run away from player either. 
                if(setting.stamina >30f && setting.stamina <=60f){
                    animator.SetTrigger("Counter");
                    animator.SetInteger("Strafe",StrafeDirection());
                    //if the player tries to attack.
                    if(distance <=2f){
                            
                    }

                    //if the player not aggressively,then keep the distance till stanima cover.

                }
                //if stanima is high, then try to attack the player.
                if(setting.stamina >60f){

                }
            }
            //if the distance is not close enough
            else{
                gameobject.transform.LookAt(playerPosition);
                animator.SetBool("GetClose",true);
            }
        }
    }

    void Addon_Attack_Animation(){
        Animator animator = gameobject.GetComponent<Animator>();
        animator.SetTrigger("Counter");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    int AttackPart(){
        int PartAttackDetermine =Random.Range(0, 3);
        return PartAttackDetermine;
    }
    int StrafeDirection(){
        int StrafeDetermine =Random.Range(0, 2);
        return StrafeDetermine;
    }
}
