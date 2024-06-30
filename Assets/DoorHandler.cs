using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("openDoor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
