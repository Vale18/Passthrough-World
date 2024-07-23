using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : ICatAction
{
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private GameObject target;
    NavMeshAgent agent;
    private LookAt lookAt;

    public void AwakeAction(NavMeshAgent agent, params object[] parameters)
    {
        this.agent = agent;
        lookAt = agent.GameObject().GetComponent<LookAt>();
    }
    public void StartAction()
    {
        var mainCameraList = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (var mainCamera in mainCameraList)
        {
            if (mainCamera.name == "CenterEyeAnchor");
                target = mainCamera;
        }
        
    }

    public void UpdateAction()
    {
        Vector3 infrontOfTarget = target.transform.position + target.transform.forward * 0.3f;
        agent.destination = infrontOfTarget;
        // Setze isComplete auf true, wenn die Aktion beendet ist
    }

    public void FinishAction()
    {
        isComplete = true;
    }
    
}
