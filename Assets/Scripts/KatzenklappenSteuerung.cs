using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KatzenklappenSteuerung : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent catAgent;
    private GameObject cat;
    private bool isUsingOffMeshLink = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cat = GameObject.FindWithTag("Cat");
        catAgent = cat.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (catAgent.isOnOffMeshLink && !isUsingOffMeshLink)
        {
            // Der Agent hat gerade begonnen, den Off-Mesh Link zu benutzen
            isUsingOffMeshLink = true;
            OnAgentStartUsingLink();
        }
        else if (!catAgent.isOnOffMeshLink && isUsingOffMeshLink)
        {
            // Der Agent hat gerade den Off-Mesh Link verlassen
            isUsingOffMeshLink = false;
            StartCoroutine(OnAgentStopUsingLink());
        }
    }

    void OnAgentStartUsingLink()
    {
        Vector3 direction = catAgent.currentOffMeshLinkData.endPos - catAgent.currentOffMeshLinkData.startPos;

        if (Vector3.Dot(transform.forward, direction) < 0)
        {
            animator.SetTrigger("OpenFront");
        }
        else
        {
            animator.SetTrigger("OpenBack");
        }
    }

    IEnumerator OnAgentStopUsingLink()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("CloseFront");
        animator.SetTrigger("CloseBack");
    }
  
}
