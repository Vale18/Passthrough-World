using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatEventHandler : MonoBehaviour
{
    private bool initComplete = false;
    private float timer = 0f;
    private CatActionController actionController;
    public Transform destinationCloseToPC;
    public GameObject door;
    public string wandererNavMeshArea;
    void Start()
    {
        SpawnAgent.OnCatInitialized += InitCatEventHandler;
    }

    private void InitCatEventHandler()
    {
        var cat = GameObject.FindWithTag("Cat");
        if (cat != null)
        {
            actionController = cat.GetComponent<CatActionController>();
            StartCoroutine(StartActionAfterDelay());
        }
        else
        {
            Debug.Log("Cat not found in Scene");
        }
        
    }

    IEnumerator StartActionAfterDelay()
    {
        yield return new WaitForSeconds(5);
        actionController.EnqueueAction(new GoToTarget(),destinationCloseToPC.position);
        actionController.EnqueueAction(new WandererAction(), 4f, 3f, wandererNavMeshArea);
        initComplete = true;
    }
    IEnumerator CatReactsDelayed()
    {
        yield return new WaitForSeconds(5);
        actionController.FinishCurrentAction();
        actionController.EnqueueAction(new ReactToVisitor());
        actionController.EnqueueAction(new DoorHandler(), door);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && initComplete)
        {
            StartCoroutine(CatReactsDelayed());
        }
    }

    /*void Update() //possibility user never goes in front of window
    {
        if (initComplete)
        {
            timer += Time.deltaTime;
            if (timer == 60f) 
            {
                StartCoroutine(CatReactsDelayed());
            }
        }
    }*/ 
}
