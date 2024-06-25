using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VirtualSpaceSpawner : MonoBehaviour
{
    [FormerlySerializedAs("prefabToPlace")] public GameObject outsideEnvironment;
    public GameObject insideEnvironment;
    
    // Start is called before the first frame update
    void Start()
    {
        if(outsideEnvironment != null)
            PlacePrefab(outsideEnvironment);
        if(insideEnvironment != null)
            PlacePrefab(insideEnvironment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlacePrefab(GameObject prefabToPlace)
    {
        Vector3 thisPosition = transform.position;
        thisPosition.y = 0.0f;
        thisPosition.y += prefabToPlace.transform.position.y;
        Quaternion thisRotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        Instantiate(prefabToPlace, thisPosition, thisRotation);
    }
}
