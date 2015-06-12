using UnityEngine;
using System.Collections;

public class PlacePrizes : MonoBehaviour {

	public RandomnessScript prizes;
	public GameObject number;
	
	public Transform target1;

	public Transform target1_2;

	public GameObject newNumber;

	public GameObject newTarget;

	public GameObject newEndtarget;

	bool doLerps;
	bool lerp;
	bool secLerp;
	float duration = 2.5f; // This will be your time in seconds.
	float smoothness = 0.02f;

	// Use this for initialization
	void Start () {
		//DELETe THIS
		lerp = false;
		secLerp = false;
		doLerps = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CheckBox0(int boxNumber)
	{
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
	}



	IEnumerator LerpPosition()
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		
		while(progress < 1)
		{
			if(lerp)
			{
			newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newTarget.transform.position,progress);
			newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newTarget.transform.localScale,progress);
			newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newTarget.transform.rotation,progress);
				if(newNumber.transform.position == newTarget.transform.position)
				{
					lerp = false;
					secLerp = true;
					
					Debug.Log("GO BACK");
				}
			}

			if(secLerp)
			{
				newNumber.transform.position = Vector3.Lerp(newNumber.transform.position,newEndtarget.transform.position,progress);
				newNumber.transform.localScale = Vector3.Lerp(newNumber.transform.localScale,newEndtarget.transform.localScale,progress);
				newNumber.transform.rotation = Quaternion.Slerp(newNumber.transform.rotation,newEndtarget.transform.rotation,progress);

				
			}
			//number.transform.position = Vector3.Lerp(number.transform.position,target1_2.transform.position,progress);
			//number.transform.localScale = Vector3.Lerp(number.transform.localScale,target1_2.transform.localScale,progress);

			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		progress = 0;
		StopAllCoroutines ();
		return true;
	}
	

}
