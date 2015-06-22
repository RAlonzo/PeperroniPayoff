using UnityEngine;
using System.Collections;

public class BoxAnimations : MonoBehaviour {
	public Animation[] pizzasOpening = new Animation[9];
	public AnimationClip Open;
	public AnimationClip Close;
	// Use this for initialization
	void Start () {
		foreach (Animation pizzaopen in pizzasOpening) {
			//for every sing box, add an animation clip for open and close
			pizzaopen.AddClip(Open,"Open");
			pizzaopen.AddClip(Close,"Close");
			pizzaopen["Close"].speed = 6.0f;		//set the speed to 6.0 so that it is faster
			pizzaopen.Stop();						//make sure it does not happen at the beggining
		}
	}

	public void OpenBoxes()
	{
		foreach (Animation pizzaopen in pizzasOpening) {
			//when you hit play, open all the boxes at the same time
			pizzaopen.Play("Open");
		}
	}

	public void CloseBoxes(int boxNum)
	{
		//when you click a box, the button will pass the number of the box to the array, and shut only that box
		//pizzasOpening[boxNum].PlayQueued("Close");
		pizzasOpening [boxNum].Play ("Close");
	}

}


