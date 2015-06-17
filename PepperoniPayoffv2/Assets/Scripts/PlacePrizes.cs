using UnityEngine;
using System.Collections;

public class PlacePrizes : MonoBehaviour {
	
	public RandomnessScript prizes;

	public GameObject particlePrefab;

	private GameObject number;
	
	
	private GameObject newNumber;
	
	private GameObject newTarget;
	
	private GameObject newEndtarget;
	
	public GameObject blocker;
	
	bool doLerps;
	bool lerp;
	bool secLerp;
	
	
	// Use this for initialization
	void Start () {
		//DELETe THIS
		lerp = false;
		blocker.SetActive (false);
	}

	
	public void CheckBox0(int boxNumber)
	{
		//The script finds the proper gameobject by its self so that we don't need to drag in.
		//When the button is pressed, it calls the number of the pizza box, which tells the code which placement of the numbers to use
		//************************************************************************************************
		//***IMPORTANT : DO NOT change the names of anything that has to do with numbers in heirarchy.****
		newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
		newTarget = GameObject.Find("0" + prizes.numbersForMatrix[boxNumber] + "Target");
		newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
		if(newNumber == GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text"))
		{
			StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
			Instantiate(particlePrefab,newNumber.transform.position,Quaternion.identity);	
		}
		}
	
	
	
	IEnumerator LerpPosition()
	{
		lerp = true;
		float duration = 2.5f; // This will be your time in seconds.
		float smoothness = 0.02f;
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		secLerp = false;
		blocker.SetActive (true);
		while(progress < 1)
		{
			if(lerp)
			{
				//Lerp the selected number from the correct table to the screen
				newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newTarget.transform.position,progress);
				newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newTarget.transform.localScale,progress);
				newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newTarget.transform.rotation,progress);
				if(newNumber.transform.position == newTarget.transform.position)
				{
					//What happens when the number gets to the screen?
					lerp = false;
					secLerp = true;
				}
			}
			
			if(secLerp)
			{
				//Lerp Back to table
				newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newEndtarget.transform.position,progress);
				newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newEndtarget.transform.localScale,progress);
				newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newEndtarget.transform.rotation,progress);
			}
			//number.transform.position = Vector3.Lerp(number.transform.position,target1_2.transform.position,progress);
			//number.transform.localScale = Vector3.Lerp(number.transform.localScale,target1_2.transform.localScale,progress);
			
			//Don't Touch this unless absolutley needed.
			progress += smoothness;
			yield return new WaitForSeconds(smoothness);
		}
		blocker.SetActive (false);
		secLerp = false;
		progress = 0;
		StopAllCoroutines (); //Just to make sure there is nothing slowing down the game in the background
		return true;
	}
	
	
	
}
