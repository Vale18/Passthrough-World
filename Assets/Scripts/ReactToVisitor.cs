using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ReactToVisitor : ICatAction
{
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private GameObject target;
    NavMeshAgent agent;
    private float targetHeight;
    private float timer;
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
        timer += Time.deltaTime;
        switch (timer)
        {
            case <= 1f: //Time to TurnAround
                agent.destination = target.transform.position;
                break;
            case <= 6f: //Look at Target
                agent.destination = agent.transform.position;
                lookAt.lookAtTargetPosition = target.transform.position;
                break;
            case >= 6f: //MoveToTarget
                Vector3 infrontOfTarget = target.transform.position + target.transform.forward * 0.3f;
                agent.destination = infrontOfTarget;
                if(agent.remainingDistance <= 0.1f)
                    FinishAction();
                break;
        }
    }

    public void FinishAction()
    {
        isComplete = true;
    }
    
}
