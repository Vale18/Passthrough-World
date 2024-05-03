using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInWindowsRuntime : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
#if UNITY_EDITOR
        Destroy(gameObject);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
