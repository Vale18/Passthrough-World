using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorOpen : MonoBehaviour
{
    public GameObject door;

    private Animator doorAnimator;

    private bool doorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doorOpen)
        {
            doorAnimator.SetTrigger("OpenDoor");
            doorOpen = true;
        }
            
    }
}
