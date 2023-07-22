using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockOnCameraManager : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;
    public Transform player;
    public Transform lockOnTarget;
    // Start is called before the first frame update
    void Start()
    {
        player =GameObject.Find("CameraFocusPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddTarget(Transform targetTransform, int targetWeight)
    {
        
    }
}
