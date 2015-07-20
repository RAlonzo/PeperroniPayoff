using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {


	public GameObject splashPanal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideSplash(int toppingNumber)
	{
		splashPanal.SetActive(false);
		GameObject.Find("OverLay" + toppingNumber).SetActive(false);
	}
}
