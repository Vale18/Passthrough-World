using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : ICatAction
{
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private GameObject target;
    UnityEngine.AI.NavMeshAgent agent;

    public void AwakeAction(NavMeshAgent agent, params object[] parameters)
    {
        this.agent = agent;
    }
    public void StartAction()
    {
        target = GameObject.FindWithTag("MainCamera");
    }

    public void UpdateAction()
    {
        Vector3 infrontOfTarget = target.transform.position + target.transform.forward * 0.3f;
        agent.destination = infrontOfTarget;
        // Aktualisiere die Aktion
        // Setze isComplete auf true, wenn die Aktion beendet ist
    }

    public void FinishAction()
    {
        isComplete = true;
    }
    
}
