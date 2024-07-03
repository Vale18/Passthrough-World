using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgent : MonoBehaviour
{
    public static event Action OnCatInitialized;
    // Start is called before the first frame update
    [SerializeField] private GameObject cat;
    [SerializeField] private Transform spawnPositionCat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAgentCat()
    {
        GameObject catInstance = Instantiate(cat, spawnPositionCat.position,cat.transform.rotation);
        StartCoroutine(InvokeInitializationEvent());
    }
    private IEnumerator InvokeInitializationEvent()
    {
        // Wait one frame to make sure, cat is initialized
        yield return null;
        OnCatInitialized?.Invoke();
    }
}