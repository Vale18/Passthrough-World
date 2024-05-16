using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{

    void Start()
    {
        int settingsCount = NavMesh.GetSettingsCount();

        for (int i = 0; i < settingsCount; i++)
        {
            NavMeshBuildSettings settings = NavMesh.GetSettingsByIndex(i);
            if (settings.agentTypeID == NavMesh.GetSettingsByIndex(i).agentTypeID)
            {
                Debug.Log("Index für 'cat' Agententyp gefunden: " + i);
                /*break;*/
            }
        }
    }

    public void InitializeNavMesh()
    {
        /*FindObjForNavMesh("")*/
        GameObject floorAR = FindObjectForNavMesh("FLOOR");
        // Füge der Ebene eine NavMeshSurface-Komponente hinzu
        var navMeshSurface = floorAR.AddComponent<NavMeshSurface>();
        // Baken der NavMesh zur Laufzeit
        SetUpNavMesh(navMeshSurface);
        BakeNavMesh(navMeshSurface);
    }

    void BakeNavMesh(NavMeshSurface navMeshSurface)
    {
        
        // Starte das Baken der NavMesh zur Laufzeit
        navMeshSurface.BuildNavMesh();
    }

    void SetUpNavMesh(NavMeshSurface navMeshSurface)
    {
        navMeshSurface.agentTypeID = NavMesh.GetSettingsByIndex(1).agentTypeID;
    }

    GameObject FindObjectForNavMesh(string gameObjName)
    {
        string fullEffectMeshPath = $"{gameObjName}/{gameObjName}_EffectMesh";
        Debug.Log(fullEffectMeshPath);
        MRUKRoom mrukComponent = FindObjectOfType<MRUKRoom>();
        GameObject mrukObject = mrukComponent.gameObject;
        var navMeshObj = mrukObject.transform.Find(fullEffectMeshPath).gameObject;
        return navMeshObj;
    }
}
