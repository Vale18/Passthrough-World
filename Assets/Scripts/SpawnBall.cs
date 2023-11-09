using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);
            Rigidbody spawnBallRB = ball.GetComponent<Rigidbody>();
            spawnBallRB.velocity = transform.forward * spawnSpeed;
        }
    }
}
