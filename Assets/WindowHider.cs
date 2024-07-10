using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowHider : MonoBehaviour
{
    private GameObject window;

    private Renderer windowRenderer;
    // Start is called before the first frame update
    void Start()
    {
        window = GameObject.FindWithTag("Window");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            window.SetActive(false);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            window.SetActive(true);
        }
    }
}
