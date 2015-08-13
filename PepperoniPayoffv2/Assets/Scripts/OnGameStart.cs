using UnityEngine;
using System.Collections;

public class OnGameStart : MonoBehaviour {

	public Animation cameraIn;
	public Sounds soundScript;

	public GameObject characters;

	// Use this for initialization
	public void doBeggingStuff() 
	{
		cameraIn.CrossFade("CameraIn");
		soundScript.activateSound();
		characters.SetActive(true);
	}

	// Update is called once per frame
	void Update () {

	
	}
}
