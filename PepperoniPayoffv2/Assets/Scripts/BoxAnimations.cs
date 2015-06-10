using UnityEngine;
using System.Collections;

public class BoxAnimations : MonoBehaviour {
	public Animation[] pizzasOpening = new Animation[9];
	// Use this for initialization
	void Start () {
		foreach (Animation pizzaopen in pizzasOpening) {
			pizzaopen.Stop();
		}
	}

	public void OpenBoxes()
	{
		foreach (Animation pizzaopen in pizzasOpening) {
			pizzaopen.Play();
		}
	}
}
