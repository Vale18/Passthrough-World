using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatActionController : MonoBehaviour
{
    private Queue<ICatAction> actionQueue = new Queue<ICatAction>();
    private ICatAction currentAction;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (currentAction == null || currentAction.IsComplete)
        {
            if (actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
                currentAction.StartAction();
            }
        }
        else
        {
            currentAction.UpdateAction();
        }
    }

    public void EnqueueAction(ICatAction action, params object[] parameters)
    {
        actionQueue.Enqueue(action);
        action.AwakeAction(agent, parameters);
    }

    public void FinishCurrentAction()
    {
        if(currentAction != null)
            currentAction.FinishAction();
    }
}