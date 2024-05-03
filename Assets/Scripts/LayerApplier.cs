using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class LayerApplier : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GetRoomObjectsAndApplyLayer()
    {
        MRUKRoom mrukComponent = FindObjectOfType<MRUKRoom>();
        GameObject mrukObject = mrukComponent.gameObject;

        ApplyLayer(mrukObject, "Wall");
    }
    private void ApplyLayer(GameObject obj, string layerName) {
        int layer = LayerMask.NameToLayer(layerName);
        obj.layer = layer;

        foreach (Transform child in obj.transform) {
            ApplyLayer(child.gameObject, layerName);
        }
    }
}
