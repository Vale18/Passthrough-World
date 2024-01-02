using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnSpeed = 5f;
    public OVRSkeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            SpawningBall();
        }
        
    }
    public void SpawningBall()
    {
        GameObject ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);
        Rigidbody spawnBallRB = ball.GetComponent<Rigidbody>();
        spawnBallRB.velocity = transform.forward * spawnSpeed;
    }
/* public void SpawningBallOutOfIndex()
{
    // Find the index fingertip bone
    OVRBone indexTipBone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip];
    if (indexTipBone == null) return;

    // Get the global position and rotation of the index fingertip
    Vector3 indexTipPosition = indexTipBone.Transform.position;
    Quaternion indexTipRotation = indexTipBone.Transform.rotation;
    Quaternion rotationOffset = Quaternion.Euler(90, 90, 0);
    indexTipRotation *= rotationOffset;
    // Instantiate the ball at the index fingertip position with the global rotation
    GameObject ball = Instantiate(ballPrefab, indexTipPosition, indexTipRotation);
    Rigidbody spawnBallRB = ball.GetComponent<Rigidbody>();

    // Adjust the velocity direction using local forward transformed to world space
    Vector3 velocityDirection = indexTipBone.Transform.TransformDirection(Vector3.forward);
    spawnBallRB.velocity = ball.transform.forward * spawnSpeed;
} */
public void SpawningBallOutOfIndex()
{
    // Find the index fingertip and a lower joint bones
    OVRBone indexTipBone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip];
    OVRBone indexMidBone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Index2]; // For example, the middle bone of the index finger

    if (indexTipBone == null || indexMidBone == null) return;

    // Get the global positions of the bones
    Vector3 indexTipPosition = indexTipBone.Transform.position;
    Vector3 indexMidPosition = indexMidBone.Transform.position;

    // Calculate the direction from the middle bone to the fingertip
    Vector3 direction = (indexTipPosition - indexMidPosition).normalized;

    // Instantiate the ball at the index fingertip position
    GameObject ball = Instantiate(ballPrefab, indexTipPosition, Quaternion.identity);
    Rigidbody spawnBallRB = ball.GetComponent<Rigidbody>();

    // Set the velocity of the ball to follow the finger direction
    spawnBallRB.velocity = direction * spawnSpeed;
}



}
