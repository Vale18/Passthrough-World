using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTranslateOnSpawn : MonoBehaviour
{

    public Vector3 position = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        // Assuming 'obj' is the object you've placed
        this.transform.Translate(position, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
