using UnityEngine;
using System.Collections;





public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamTexture webCam = new WebCamTexture();
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = webCam;
		webCam.Play();
	}
 	
	// Update is called once per frame
	void Update () {
	
	}
}
