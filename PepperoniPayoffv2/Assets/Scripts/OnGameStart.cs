using UnityEngine;
using System.Collections;

public class OnGameStart : MonoBehaviour {

	public Animation cameraIn;
	public Sounds soundScript;
	// Use this for initialization
	void Start () {
		cameraIn.CrossFade("CameraIn");
		soundScript.activateSound();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
