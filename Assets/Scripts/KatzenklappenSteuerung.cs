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

    private bool catFound = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SpawnAgent.OnCatInitialized += FindCatInScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (!catFound)
        {
            Debug.Log("NotFound");
            return;
        }
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
    /// <summary>
    /// Wait until Room and cat are initialized before searching scene for cat
    /// </summary>
    /// <returns></returns>
    void FindCatInScene()
    {
        cat = GameObject.FindWithTag("Cat");
        if (cat != null)
        {
            catAgent = cat.GetComponent<NavMeshAgent>();
            catFound = true;
            Debug.Log("Cat found in scene.");
            SpawnAgent.OnCatInitialized -= FindCatInScene;
        }
        else
        {
            Debug.LogWarning("Cat not found in scene.");
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
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("CloseFront");
        animator.SetTrigger("CloseBack");
    }
  
}
