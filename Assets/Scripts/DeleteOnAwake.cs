using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnAwake : MonoBehaviour
{
    [SerializeField]
    private bool destroy = true;
    void Awake()
    {
        DestroyThis(destroy);
    }
    void DestroyThis(bool destroy)
    {
        if(destroy)
            Destroy(gameObject);
    }
    
}
