using UnityEngine;
using System.Collections;

// Attach this script to your Camera in the scene

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class CameraRainFX : MonoBehaviour 
{
	public GameObject rainPlain;
	public float maxAlpha = 1f;
	public float minAlpha = 0f;
	public AudioSource rainSound;
	public float maxSoundVol = 1f;
	public float minSoundVol = 0.2f;
	public string tagName = "NoRain"; // Trigger Collider must have this tag to disable/Enable the rain effect
	public string shaderColorPropName = "_TintColor";
	
	public float fadeTime = 1.0f;
	
	public float lookUpAngle = 45f;
	
	Rigidbody rb;
	Transform cam;
	
	float t = 0;
	bool isInTrigger = false;
	bool setOn;
	bool setOff;
	
	//------------------------------------------------------------------------------------------------------------------
	
	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		FadeAlpha (maxAlpha, maxSoundVol);
	}
	//------------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other)
	{
		if(other.CompareTag(tagName))
		{
			isInTrigger = true; // Enter
			setOff = true;
		}
	}
	//------------------------------------------------------------------------------------------------------------------
	void OnTriggerExit (Collider other)
	{
		if(other.CompareTag(tagName))
		{
			isInTrigger = false; // Exit
			setOn = true;
		}
	}
	//------------------------------------------------------------------------------------------------------------------
	
	void FadeAlpha (float alpha, float volume)
	{
		Color c = rainPlain.GetComponent<Renderer>().sharedMaterial.GetColor(shaderColorPropName);
		if (c.a != alpha) 
		{
			t += Time.deltaTime * fadeTime;
			
			c.a = Mathf.SmoothStep(c.a, alpha, t);
			
			if(rainSound)
				rainSound.GetComponent<AudioSource>().volume =  Mathf.SmoothStep(rainSound.GetComponent<AudioSource>().volume, volume, t);
			
			rainPlain.GetComponent<Renderer>().sharedMaterial.SetColor(shaderColorPropName, c);
		}
		else
		{
			t = 0;
			setOn = false;
			setOff = false;
		}
	}
	
	//------------------------------------------------------------------------------------------------------------------
	void Update ()
	{
		if(setOn)
		{
			FadeAlpha (maxAlpha, maxSoundVol);
		}
		else if(setOff)
		{
			FadeAlpha (minAlpha, minSoundVol);
		}
		
		
				
		if (!isInTrigger)
		{
			if(Vector3.Angle(cam.forward, Vector3.up) < lookUpAngle || Vector3.Angle(cam.forward, -Vector3.up) < lookUpAngle)
			{
				FadeAlpha (minAlpha, minSoundVol); // Fade out
			}
			else //if(Vector3.Angle(cam.forward, Vector3.up) > lookUpAngle  || Vector3.Angle(cam.forward, -Vector3.up) > lookUpAngle)
			{
				FadeAlpha (maxAlpha, maxSoundVol); // Fade in
			}
		}
		
	}
	//------------------------------------------------------------------------------------------------------------------
}
