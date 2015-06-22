using UnityEngine;
using System.Collections;

public class PlacePrizes : MonoBehaviour {
	
	public RandomnessScript prizes;
	private GameObject number;
	
	
	private GameObject newNumber;
	
	private GameObject newTarget;
	
	private GameObject newEndtarget;
	
	public GameObject blocker;

	private GameObject[] numOrder = new GameObject[9];
	private GameObject[] tarOrder = new GameObject[9];
	

	bool doLerps;
	bool lerp;
	bool secLerp;

	int index;

	public bool inTransit0;
	public bool inTransit1;
	
	
	
	// Use this for initialization
	void Start () {
		//DELETe THIS
		index = -1;
		inTransit0 = false;
		inTransit1 = false;
		lerp = false;
		blocker.SetActive (false);
		newNumber = null;
		newTarget = null;
		newEndtarget = null;
	}

	
	public void CheckBox0(int boxNumber)
	{
		//The script finds the proper gameobject by its self so that we don't need to drag in.
		//When the button is pressed, it calls the number of the pizza box, which tells the code which placement of the numbers to use
		//************************************************************************************************
		//***IMPORTANT : DO NOT change the names of anything that has to do with numbers in heirarchy.****
		//StopAllCoroutines();
		index++;
		newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
		newTarget = GameObject.Find("0" + prizes.numbersForMatrix[boxNumber] + "Target");
		newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
<<<<<<< HEAD
		numOrder[index] = newNumber;
		tarOrder[index] = newEndtarget;
		if(newNumber == GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text"))
		{
			StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
			Instantiate(particlePrefab,newNumber.transform.position,Quaternion.identity);	
		}

		}
=======
		StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
	}
>>>>>>> origin/master
	
	

	IEnumerator LerpPosition()
	{

		if(newNumber == null)
		{
			newNumber = GameObject.Find(0+""+prizes.numbersForMatrix[0] + "Text");
		}
		if(newTarget == null)
		{
			newTarget = GameObject.Find("0" + prizes.numbersForMatrix[0] + "Target");
		}
		if(newEndtarget == null)
		{
			newEndtarget = GameObject.Find(0+""+prizes.numbersForMatrix[0]+ "endTarget");	
		}
		lerp = true;
		float duration = 2.5f; // This will be your time in seconds.
		float smoothness = 0.02f;
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.

		int i = index;
		secLerp = false;
		blocker.SetActive (true);

		while(progress < 1)
		{
				if(lerp && !secLerp)
			{
				//Lerp the selected number from the correct table to the screen

				//used to be NewNumber

				inTransit0 = true;
				numOrder[i].transform.position = Vector3.Lerp(numOrder[i].transform.position,newTarget.transform.position,progress);
				numOrder[i].transform.localScale = Vector3.Lerp(numOrder[i].transform.localScale,newTarget.transform.localScale,progress);
				numOrder[i].transform.rotation = Quaternion.Slerp(numOrder[i].transform.rotation,newTarget.transform.rotation,progress);
				if(numOrder[i].transform.position == newTarget.transform.position)
				{
					//What happens when the number gets to the screen?
					lerp = false;
					secLerp = true;
				}
			}
			
			if(secLerp)
			{
				//Lerp Back to table

				numOrder[i].transform.position = Vector3.Lerp(numOrder[i].transform.position,tarOrder[i].transform.position,progress);
				numOrder[i].transform.localScale = Vector3.Lerp(numOrder[i].transform.localScale,tarOrder[i].transform.localScale,progress);
				numOrder[i].transform.rotation = Quaternion.Slerp(numOrder[i].transform.rotation,tarOrder[i].transform.rotation,progress);
			}
			//number.transform.position = Vector3.Lerp(number.transform.position,target1_2.transform.position,progress);
			//number.transform.localScale = Vector3.Lerp(number.transform.localScale,target1_2.transform.localScale,progress);
			
			//Don't Touch this unless absolutley needed.
			progress += smoothness;
			yield return new WaitForSeconds(.000000001f);
			//yield return new WaitForSeconds(.0002f);


		}
		
		inTransit0 = false;
		blocker.SetActive (false);
		secLerp = false;
		progress = 0;
		StopAllCoroutines (); //Just to make sure there is nothing slowing down the game in the background
		return true;
	}


	
	
	
}
