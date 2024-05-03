using UnityEngine;
using System.Collections;

public class SmoothFollowTarget : MonoBehaviour
{
	public Transform target;
	public float height = 1.0f;
	
	void Update () 
	{
		Vector3 tVec = new Vector3(target.position.x, target.position.y * height, target.position.z);
		transform.position = tVec;
	}
}