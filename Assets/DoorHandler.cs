using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DoorHandler : ICatAction
{
    private bool isComplete = false;
    public bool IsComplete => isComplete;
    private GameObject doorTarget;
    NavMeshAgent agent;
    private Animator catAnimator, doorAnimator;
    private float stoppingDistance = 0.4f;
    private bool waitForSitDown = false;
    public void AwakeAction(NavMeshAgent agent, params object[] parameters)
    {
        this.agent = agent;
        catAnimator = agent.GameObject().GetComponent<Animator>();
        doorTarget = (GameObject)parameters[0];
        doorAnimator = doorTarget.GetComponent<Animator>();
    }

    public void StartAction()
    {
        agent.destination = doorTarget.transform.position - doorTarget.transform.forward * stoppingDistance;
    }

    public void UpdateAction()
    {
        if (agent.remainingDistance == 0 && !waitForSitDown)
        {
            waitForSitDown = true;
            catAnimator.SetTrigger("SitDown");
            agent.updatePosition = false;
        }
        if (waitForSitDown) //Check if sitdown finished
        {
            if (catAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2.0f)
            {
                /*doorAnimator.SetTrigger("OpenDoor");*/
                FinishAction();
            }
        }
    }

    public void FinishAction()
    {
        isComplete = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
