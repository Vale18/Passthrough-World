using UnityEngine;
using UnityEngine.AI;

public class Wanderer : MonoBehaviour
{
    private NavMeshAgent agent;
    public float wanderRadius = 1.5f;
    public float wanderInterval = 3f;
    public string navMeshAreaName;
    private int navMeshArea;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        navMeshArea = NavMesh.GetAreaFromName(navMeshAreaName);
        Debug.Log(navMeshArea);
        timer = wanderInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, navMeshArea);
            agent.SetDestination(newPosition);
            timer = 0;
        }
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