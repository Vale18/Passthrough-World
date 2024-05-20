using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private GameObject target;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("MainCamera");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 infrontOfTarget = target.transform.position + target.transform.forward * 0.3f;
        agent.destination = infrontOfTarget;
    }
}
