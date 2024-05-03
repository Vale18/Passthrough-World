using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Card" && other.gameObject.GetComponent<Animator>().GetBool("cardActive") == false)
            {
                other.gameObject.GetComponent<Animator>().SetBool("cardActive", true);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                Debug.Log("Card is active");
            }

        }
    void OnTriggerExit(Collider other)
        {
/*             if(other.tag == "Card")
            {
                other.gameObject.GetComponent<Animator>().SetBool("cardActive", false);
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                 Debug.Log("Card is inActive");
            } */
        }
}
