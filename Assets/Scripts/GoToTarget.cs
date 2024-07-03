using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToTarget : ICatAction
{
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private Vector3 target;
    UnityEngine.AI.NavMeshAgent agent;

    public void AwakeAction(NavMeshAgent agent, params object[] parameters)
    {
        this.agent = agent;
        target = (Vector3)parameters[0];
    }
    public void StartAction()
    {
        agent.destination = target;
    }

    public void UpdateAction()
    {
        if (agent.remainingDistance <= 0)
        {
            FinishAction();
        }
    }

    public void FinishAction()
    {
        isComplete = true;
    }
}
