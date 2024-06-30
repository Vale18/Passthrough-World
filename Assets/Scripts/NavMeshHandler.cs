using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using UnityEngine.AI;

public class NavMeshHandler : MonoBehaviour
{ 
    private NavMeshSurface navMeshSurface;
    void Awake()
    {
       navMeshSurface = GetComponent<NavMeshSurface>();
    }

    void Start()
    {
        BakeNavMesh();
        GetComponent<SpawnAgent>().SpawnAgentCat();
    }
    [ContextMenu("BakeNavMesh")]
    public void BakeNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
    void SetUpNavMesh(NavMeshSurface navMeshSurface)
    {
        navMeshSurface.agentTypeID = NavMesh.GetSettingsByIndex(1).agentTypeID;
    }
}
