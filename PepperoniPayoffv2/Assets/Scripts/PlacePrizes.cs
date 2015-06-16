using UnityEngine;
using System.Collections;

public class PlacePrizes : MonoBehaviour {

	public RandomnessScript prizes;
<<<<<<< HEAD
	private GameObject number;


	private GameObject newNumber;

	private GameObject newTarget;

	private GameObject newEndtarget;

	public GameObject blocker;
=======
	public GameObject number;
	
	public Transform target1;

	public Transform target1_2;

	public GameObject newNumber;

	public GameObject newTarget;

	public GameObject newEndtarget;
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44

	bool doLerps;
	bool lerp;
	bool secLerp;
<<<<<<< HEAD

=======
	float duration = 2.5f; // This will be your time in seconds.
	float smoothness = 0.02f;
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44

	// Use this for initialization
	void Start () {
		//DELETe THIS
		lerp = false;
<<<<<<< HEAD
		blocker.SetActive (false);
=======
		secLerp = false;
		doLerps = false;
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CheckBox0(int boxNumber)
	{
<<<<<<< HEAD
			//The script finds the proper gameobject by its self so that we don't need to drag in.
			//When the button is pressed, it calls the number of the pizza box, which tells the code which placement of the numbers to use
			//IMPORTANT : DO NOT change the names of anything that has to do with numbers in heirarchy.
			newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
			newTarget = GameObject.Find("0" + prizes.numbersForMatrix[boxNumber] + "Target");
			newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
			StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
			
=======
		lerp = true;
		//if(prizes.prize0 == 1)
		//{
			newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
			newTarget = GameObject.Find("0" + prizes.numbersForMatrix[boxNumber] + "Target");
			newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
			StartCoroutine("LerpPosition");
			//newNumber.SetActive(true);
			//number.SetActive(true);
		//}
//		else if (prizes.prize0 == 2) {
//			newNumber = GameObject.Find(boxNumber+""+prizes.prize0 + "Text");
//			newTarget = GameObject.Find(boxNumber+""+prizes.prize0 + "Target");
//			newEndtarget = GameObject.Find(boxNumber+""+prizes.prize0 + "endTarget");
//			
//			StartCoroutine("LerpPosition");
//			number.SetActive(true);
//		}
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
	}



	IEnumerator LerpPosition()
	{
<<<<<<< HEAD
		lerp = true;
		float duration = 2.5f; // This will be your time in seconds.
		float smoothness = 0.02f;
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		//float increment = smoothness/duration; //The amount of change to apply.
		secLerp = false;
		blocker.SetActive (true);
=======
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
		while(progress < 1)
		{
			if(lerp)
			{
<<<<<<< HEAD
			//Lerp the selected number from the correct table to the screen
=======
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
			newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newTarget.transform.position,progress);
			newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newTarget.transform.localScale,progress);
			newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newTarget.transform.rotation,progress);
				if(newNumber.transform.position == newTarget.transform.position)
				{
<<<<<<< HEAD
					//What happens when the number gets to the screen?
					lerp = false;
					secLerp = true;
=======
					lerp = false;
					secLerp = true;
					
					Debug.Log("GO BACK");
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
				}
			}

			if(secLerp)
			{
<<<<<<< HEAD
				//Lerp Back to table
				newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newEndtarget.transform.position,progress);
				newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newEndtarget.transform.localScale,progress);
				newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newEndtarget.transform.rotation,progress);
=======
				newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newEndtarget.transform.position,progress);
				newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newEndtarget.transform.localScale,progress);
				newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newEndtarget.transform.rotation,progress);

				
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44
			}
			//number.transform.position = Vector3.Lerp(number.transform.position,target1_2.transform.position,progress);
			//number.transform.localScale = Vector3.Lerp(number.transform.localScale,target1_2.transform.localScale,progress);

<<<<<<< HEAD
			//Don't Touch this unless absolutley needed.
			progress += .03f;
			yield return new WaitForSeconds(smoothness);
		}
		blocker.SetActive (false);
		secLerp = false;
		progress = 0;
		StopAllCoroutines (); //Just to make sure there is nothing slowing down the game in the background
		return true;
	}


=======
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		progress = 0;
		StopAllCoroutines ();
		return true;
	}
	
>>>>>>> c5c737facf5973c6c71df52a4499c2ff456c7d44

}
