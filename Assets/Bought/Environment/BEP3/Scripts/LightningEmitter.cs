using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningEmitter : MonoBehaviour 
{
	public int minSec = 1;
	public int maxSec = 12;
	
	public float rdmDist = 22f;
	
	public float killTime = 2f;
	
	public List<GameObject> prefabs = new List<GameObject>();
	
	bool isReady = false;
	
	//=================================================================================================================o
	void Start () 
	{
		StartCoroutine (Timer ());
		InvokeRepeating("Holder", 0f, 1.5f);
	}
	//=================================================================================================================o
	IEnumerator Timer ()
	{
		isReady = false;
		
		Vector3 ranVec = new Vector3(Random.Range(-rdmDist, rdmDist), 0, Random.Range(-rdmDist, rdmDist));
		GameObject go = (GameObject)Instantiate( prefabs[ Random.Range(0, prefabs.Count) ], transform.position + ranVec, Quaternion.identity);
		//yield return StartCoroutine(KillTimer(go));
		Destroy(go, killTime);
		yield return new WaitForSeconds (Random.Range (minSec, maxSec));
		
		isReady = true;
	}
	//=================================================================================================================o
	/*IEnumerator KillTimer (GameObject g)
	{
		yield return new WaitForSeconds (killTime);
		if(g)
			Destroy(g);
	}*/
	//=================================================================================================================o
	void Holder ()
	{
		if(prefabs.Count == 0)
			return;
		if (isReady)
		{
			StartCoroutine (Timer ());
		}
	}
	//=================================================================================================================o
}
