using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaOut : MonoBehaviour {
	public Image black;
//	public GameObject toppingCamera;
	public GameObject toppingCanvas;
	public GameObject menuCanvas;
	//public Color startingColor;
	public GameObject pepperoni;
	public GameObject payoff;
	public GameObject endPepperoni;
	public GameObject endPayoff;

	float duration = 1.0f; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.

	//void Start()
	//{
	//	FadeIn();
	//}
	
	IEnumerator LerpColor()
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		
		while(progress < 1)
		{
			black.color = Color.Lerp(Color.white, Color.clear, progress);
			pepperoni.transform.position = Vector2.Lerp (pepperoni.transform.position, endPepperoni.transform.position, progress);
			payoff.transform.position = Vector2.Lerp (payoff.transform.position, endPayoff.transform.position, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		menuCanvas.SetActive (false);
//		toppingCamera.SetActive (true);
		toppingCanvas.SetActive (true);

		return true;
	}

	public void FadeIn(){
		StartCoroutine("LerpColor");
	}
}
