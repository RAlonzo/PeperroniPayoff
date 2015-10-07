using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
	//public Image black;
	//public GameObject toppingCamera;
	//public GameObject toppingCanvas;
	//public GameObject menuCanvas;
	//public Color startingColor;
	public GameObject pepperoni;
	public GameObject payoff;
	public GameObject endPepperoni;
	public GameObject endPayoff;
	
	float duration = 2.5f; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	
	void Start()
	{
		
	}


	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator LerpColor()
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		
		while(progress < 1)
		{
			//black.color = Color.Lerp(Color.black, Color.clear, progress);
			//below will shoot the words off the screen (not seen if loader is there)
			pepperoni.transform.position = Vector2.Lerp (pepperoni.transform.position, endPepperoni.transform.position, progress);
			payoff.transform.position = Vector2.Lerp (payoff.transform.position, endPayoff.transform.position, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		//menuCanvas.SetActive (false);
		//toppingCamera.SetActive (true);
		//toppingCanvas.SetActive (true);
		yield return true;
	}
	
	public void FadeIn(){
		Application.LoadLevel(2); //Show preLoader screen before game!
		//StartCoroutine("LerpColor");
	}
}
