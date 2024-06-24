using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzenklappenSteuerung : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter" + other.tag + other.name);
        if (other.CompareTag("Cat"))
        {
            Debug.Log("OnTriggerEnter");
            if (other.transform.position.z < transform.position.z)
            {
                animator.SetTrigger("OpenFront");
            }
            else
            {
                animator.SetTrigger("OpenBack");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (other.CompareTag("Cat"))
        {
            animator.SetTrigger("CloseFront");
            animator.SetTrigger("CloseBack");
        }
    }
}
