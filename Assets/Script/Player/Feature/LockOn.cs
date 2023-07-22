using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockOn : MonoBehaviour
{
    public HashSet<Transform> locktarget =new HashSet<Transform>();
    public Collider lockrange;
    public Animator animator;

    //--------------Camera----------------------
    public CinemachineFreeLook PlayerCamera;
    public CinemachineFreeLook LockTargetCamera;
    public CinemachineMixingCamera mixingCamera;
    //------------------------------------------
    private bool IsLockEnabled =false;
    private bool ExistATargetNow =false;

    //the transform to use when the lock system is on.
    public Transform PointsToTarget;
    //the transform to use when the lock system is off.
    public Transform FreeRotate;

    //use to distance calculation.
    public Transform PlayerLoc;

    //use to re-correct the attack direction.
    public Transform playerModel;

    //------------Dynamic Variables------------
    //------------Assign on runtime------------
    [HideInInspector]public Transform playerTransform =null;
    [HideInInspector]public Transform closestTarget = null;
    //-----------------------------------------

    //add for switch target feature.
    public Transform currentlyLockedTarget =null;
    //------------------------------

    //store the distance for each elements in hashset.
    private Dictionary<Transform, float> targetDistances = new Dictionary<Transform, float>();

    public float playerCameraXAxisSpeed,playerCameraYAxisSpeed;

    void Start(){
        playerCameraXAxisSpeed =PlayerCamera.m_XAxis.m_MaxSpeed;
        playerCameraYAxisSpeed =PlayerCamera.m_YAxis.m_MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //toggle the lock-on on and off.
        if (Input.GetKeyDown("r")){
            if(locktarget.Count ==0 && IsLockEnabled ==false){
                //If there is no target can be locked.
            }else{
                IsLockEnabled =!IsLockEnabled;
            }
        }
        //

        //lock on feature.
        if(IsLockEnabled ==true){
            LockTargetCamera.enabled =true;
            animator.SetBool("LockTarget",true);
            //if this is the first time lock target.
            if(ExistATargetNow ==false){
                currentlyLockedTarget =closestTarget;
                ExistATargetNow =true;
            }
            //if the lock on system is currently lock on a target.
            //if(ExistATargetNow ==true)
            else{
                //if the player wants to switch target.
                if(Input.GetKeyDown("t")){
                    //if there exist a target which indeed closer than the currently locked target.
                    if(currentlyLockedTarget != closestTarget){
                        currentlyLockedTarget =closestTarget;
                    }
                    //if the target which is being locked is still cloest to the player.
                    else{
                        //do nothing.
                    }
                }
            }
            LockTargetCamera.Follow =PlayerLoc;
            LockTargetCamera.LookAt =currentlyLockedTarget;

            PlayerCamera.m_XAxis.m_MaxSpeed =0;
            PlayerCamera.m_YAxis.m_MaxSpeed =0;


            //if player is moving.
            if(animator.GetBool("IsWalking") || animator.GetBool("IsRunning")){
                //then the animator will choose the animation which player face to target to move.
                playerModel.LookAt(currentlyLockedTarget);
                playerTransform =PointsToTarget;
            }
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition") || animator.GetCurrentAnimatorStateInfo(0).IsName("Combo_Transition 0")){
                //we will re-correct the attack direction when transition animation playing instead of when attack animation is playing.
                playerModel.LookAt(currentlyLockedTarget);
            }
            else{
                //if the player is attacking or else, then the attack animation will not use lookAt since
                //it may caused issue (such as rotate attack, the lookAt will cause player do a goofy waving attack).
                playerTransform =FreeRotate;
            }
            //Ok this "playerTransform" thing makes the camera transition changed smoothly (except the transition between lock-on and freelook), I don't know how did I make it,
            //but just don't disable it or delete it :|
            playerTransform.LookAt(currentlyLockedTarget);

        }
        if(IsLockEnabled ==false){
            animator.SetBool("LockTarget",false);
            PlayerCamera.m_XAxis.m_MaxSpeed =playerCameraXAxisSpeed;
            PlayerCamera.m_YAxis.m_MaxSpeed =playerCameraYAxisSpeed;
            LockTargetCamera.Follow =null;
            LockTargetCamera.LookAt =null;
            LockTargetCamera.enabled =false;

            PlayerCamera.enabled =true;
            ExistATargetNow =false;
        }
        //
    }

    //the switch target feature is still needs to develop.
    void OnTriggerEnter(Collider other){
        //the lock on need character controller and a child object called "LockPoint".
        if(other.gameObject.tag =="Enemy" || other.gameObject.tag =="Enemy_Attack"){
            Transform lockPointTransform = other.gameObject.GetComponentInChildren<Transform>().Find("LockPoint");
            if (lockPointTransform != null && !locktarget.Contains(lockPointTransform)){
                locktarget.Add(lockPointTransform);
            }
        }
    }
    void OnTriggerStay(Collider other){
        foreach (var target in locktarget)
        {
            float distance = Vector3.Distance(PlayerLoc.position, target.position);
            targetDistances[target] = distance;
        }

        float smallestDistance = float.MaxValue;
        foreach (var kvp in targetDistances){
            if (kvp.Value < smallestDistance){
                smallestDistance = kvp.Value;
                closestTarget = kvp.Key;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy_Attack"){
            Transform lockPointTransform = other.gameObject.GetComponentInChildren<Transform>().Find("LockPoint");
            if (lockPointTransform != null)
            {
                locktarget.Remove(lockPointTransform);
            }
        }
    }
}
