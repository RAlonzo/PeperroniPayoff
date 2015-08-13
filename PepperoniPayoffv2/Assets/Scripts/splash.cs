using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {

	public PlacePrizes changeHighest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
