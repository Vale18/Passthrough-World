using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VirtualSpaceSpawner : MonoBehaviour
{
    [FormerlySerializedAs("prefabToPlace")] public GameObject outsideEnvironment;
    public GameObject insideEnvironment;
    private static HashSet<string> instantiatedPrefabs = new HashSet<string>();
    // Start is called before the first frame update
    void Start()
    {
        if(outsideEnvironment != null)
            TryPlacePrefab(outsideEnvironment);
        if(insideEnvironment != null)
            TryPlacePrefab(insideEnvironment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TryPlacePrefab(GameObject prefabToPlace)
    {
        string prefabName = prefabToPlace.name;
        if (!instantiatedPrefabs.Contains(prefabName))
        {
            instantiatedPrefabs.Add(prefabName);
            PlacePrefab(prefabToPlace);
        }
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
