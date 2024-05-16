using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentCatController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navAgent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.velocity.magnitude > 0f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (navAgent.remainingDistance <= 0)
        {
            animator.SetTrigger("SitDown");
        }
    }
}
