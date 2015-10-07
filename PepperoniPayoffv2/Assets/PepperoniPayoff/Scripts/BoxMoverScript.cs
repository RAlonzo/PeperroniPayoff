using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxMoverScript : MonoBehaviour {
	private string boxName;		//This is so we don't have to have a bunch of GameObjects
	private string buttonName;

	public Transform target0;
	public GameObject pizza0;

	public int BoxNum;

	private bool shutting;

	float duration = 2.5f; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	// Use this for initialization
	void Start () {
		buttonName = null;
		boxName = null;
		shutting = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator PizzaCoroutine(){
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		GameObject selectedBox = GameObject.Find (boxName);
		while (progress < 1) {
			if(shutting)
			{
				yield return new WaitForSeconds(.3f);
				shutting = false;
			}
			selectedBox.transform.position = Vector3.Lerp (selectedBox.transform.position, target0.position, progress);		//Lerps selected box to the target location
			selectedBox.transform.rotation = Quaternion.Slerp(selectedBox.transform.rotation, target0.rotation, progress);	//Slerps the rotation for cool spinny effect
			progress += increment;
			yield return new WaitForEndOfFrame();
			//yield return new WaitForSeconds (smoothness);
		}
		selectedBox.SetActive (false);
		boxName = "PizzaHolder";
		return true;
	}
	public void BoxFly(int boxNumber){
		boxName = "PizzaHolder" + boxNumber;				//Sets box name to PizzaHolder0-9, this allows us to use only one gameobject and shorten up the code.
		buttonName = "PizzaButton" + boxNumber;				//Sets the button name so that we can shut it off (this got rid of null reference after already clicked)
		GameObject button = GameObject.Find (buttonName);	//Sets the selected button to the button gameobject allowing us to deactivate it.
		button.SetActive (false);
		shutting = true;
		StartCoroutine ("PizzaCoroutine");					//Start PizzaCoroutine, lerping out the corect box.
	}
}
