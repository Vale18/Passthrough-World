using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideSpawner : MonoBehaviour
{
    public GameObject prefabToPlace;

    // Start is called before the first frame update
    void Start()
    {
        PlacePrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlacePrefab()
    {
        Vector3 thisPosition = transform.position;
        thisPosition.y = 0.0f;
        Quaternion thisRotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        Instantiate(prefabToPlace, thisPosition, thisRotation);
    }
}
