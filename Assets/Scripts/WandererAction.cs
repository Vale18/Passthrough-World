using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WandererAction : ICatAction
{
    private NavMeshAgent agent;
    public float wanderRadius = 4f;
    public float wanderInterval = 3f;
    public string navMeshAreaName;
    private int navMeshArea;
    private float timer;
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private GameObject agentObj;

    public void AwakeAction(NavMeshAgent agent, params object[] parameters)
    {
        this.agent = agent;
        agentObj = agent.GameObject();
        wanderRadius = (float)parameters[0];
        wanderInterval = (float)parameters[1];
        navMeshAreaName = (string)parameters[2];
        navMeshArea = NavMesh.GetAreaFromName(navMeshAreaName);
    }
    public void StartAction()
    {
        timer = wanderInterval;
    }
    public void UpdateAction()
    {
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            Vector3 newPosition = RandomNavSphere(agentObj.transform.position, wanderRadius, navMeshArea);
            agent.SetDestination(newPosition);
            timer = 0;
        }
    }

    public void FinishAction()
    {
        isComplete = true;
    }
    
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int navMeshArea)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, distance, 1 << navMeshArea))//Bitshift Operator 0001 - 1000
        {
            return navHit.position;
        }
        return origin;
    }
}