using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ICatAction 
{ 
    bool IsComplete { get; }
    void AwakeAction(NavMeshAgent agent, params object[] parameters);
    void StartAction();
    void UpdateAction();
    void FinishAction();
}
