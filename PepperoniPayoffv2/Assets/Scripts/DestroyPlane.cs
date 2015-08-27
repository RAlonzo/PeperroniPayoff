using UnityEngine;
using System.Collections;

public class DestroyPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= 60)
			Destroy (gameObject);
	}
}
