using UnityEngine;
using System.Collections;

public class BoxAnimations : MonoBehaviour {
	public Animation[] pizzasOpening = new Animation[9];
	public AnimationClip Open;
	public AnimationClip Close;
	// Use this for initialization
	void Start () {
		foreach (Animation pizzaopen in pizzasOpening) {
			pizzaopen.AddClip(Open,"Open");
			pizzaopen.AddClip(Close,"Close");
			pizzaopen["Close"].speed = 6.0f;
			pizzaopen.Stop();
		}
	}

	public void OpenBoxes()
	{
		foreach (Animation pizzaopen in pizzasOpening) {
			pizzaopen.Play("Open");
		}
	}

	public void CloseBoxes(int boxNum)
	{
		pizzasOpening [boxNum].Play ("Close");
	}
}
