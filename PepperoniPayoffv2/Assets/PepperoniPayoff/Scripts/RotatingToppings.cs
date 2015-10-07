using UnityEngine;
using System.Collections;

public class RotatingToppings : MonoBehaviour {
	
	public float turnSpeed = 60f;
	public bool rotatingActive = true;
	public bool once;

	float duration = 2.5f; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	// Use this for initialization
	void Start () {
		StartCoroutine ("doRotation");		
	}
	

	IEnumerator doRotation() {
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		while (progress < 1) {
			rotateTopping ();
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		if (rotatingActive) {
			StartCoroutine ("doRotation");
		}else 
		return true;
	}

	public void rotateActive (){
		if (rotatingActive) {
			rotatingActive = false;
		} else {
			StartCoroutine ("doRotation");
			rotatingActive = true;
		}
	}

	public void rotateTopping () {
		transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
	}
}
