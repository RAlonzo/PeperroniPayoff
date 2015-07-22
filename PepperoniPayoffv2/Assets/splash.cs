using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {


	public GameObject splashPanal;
	public PlacePrizes changeHighest;

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

	public void SetMaxGeneration(int highestWin)
	{
		changeHighest.highestGeneration = highestWin;
	}
	public void SetLowestGeneration(int lowestWin)
	{
		changeHighest.lowestGeneration = lowestWin;
	}
}
