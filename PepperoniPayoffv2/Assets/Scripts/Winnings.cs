using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Winnings : MonoBehaviour {

	private int winnings;
	public Image black;
	public Text amount;
	public Text ifLose;
	private int boxesRemaining;
	public RandomnessScript Counters;

	public GameObject menuCanvas;

	public GameObject STRTyouCouldHaveWon;
	public GameObject ENDyouCouldHaveWon;
	public GameObject STRTamnt;
	public GameObject ENDamnt;

	public GameObject STRTbutton;
	public GameObject ENDbutton;

	float duration = 1.0f; // This will be your time in seconds.
	float smoothness = 0.02f;

	// Use this for initialization
	void Start () {
		winnings = 0;
		boxesRemaining = 9;

		black.color = Color.clear;
		menuCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void SubtractBoxesRemaining()
	{
			boxesRemaining--;
		
		if(boxesRemaining == 0)
		{
			Debug.Log("DONE");
			menuCanvas.SetActive (true);
			StartCoroutine("LerpColor");
		}

		Debug.Log(boxesRemaining + " Boxes Remain");
	}


	IEnumerator LerpColor()
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		yield return new WaitForSeconds(1.3f);
		while(progress < 1)
		{
			black.color = Color.Lerp(Color.clear, Color.black, progress);
			progress += increment;
			
			yield return new WaitForSeconds(smoothness);
		}
			StartCoroutine("LerpText");
		
		return true;
	}


	IEnumerator LerpText()
	{
		StopCoroutine("LerpColor");
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		//yield return new WaitForSeconds(2);
		while(progress < 1)
		{
			STRTamnt.transform.position = Vector2.Lerp (STRTamnt.transform.position, ENDamnt.transform.position, progress);
			STRTyouCouldHaveWon.transform.position = Vector2.Lerp (STRTyouCouldHaveWon.transform.position, ENDyouCouldHaveWon.transform.position, progress);
			STRTbutton.transform.position = Vector2.Lerp (STRTbutton.transform.position, ENDbutton.transform.position, progress);
			progress += increment;
			
			yield return new WaitForSeconds(smoothness);
		}
		
		return true;
	}

	public void Quit()
	{
		Application.LoadLevel(0);
	}

	public void CheckForWinners()
	{
		if(Counters.counter1 >= 3)
		{
			winnings += 1;
		}
		if(Counters.counter2 >= 3)
		{
			winnings += 2;
		}
		if(Counters.counter3 >= 3)
		{
			winnings += 3;
		}
		if(Counters.counter5 >= 3)
		{
			winnings += 5;
		}
		if(Counters.counter10 >= 3)
		{
			winnings += 10;
		}
		if(Counters.counter20 >= 3)
		{
			winnings += 20;
		}
		if(Counters.counter30 >= 3)
		{
			winnings += 30;
		}
		if(Counters.counter50 >= 3)
		{
			winnings += 50;
		}
		if(Counters.counter100 >= 3)
		{
			winnings += 100;
		}
		if(Counters.counter200 >= 3)
		{
			winnings += 200;
		}
		if(Counters.counter500 >= 3)
		{
			winnings += 500;
		}
		if(Counters.counter800 >= 3)
		{
			winnings += 800;
		}
		if(winnings > 0)
			amount.text = "$" + winnings.ToString() + "!";
		else
		{
			amount.text = "";
			ifLose.text = "Sorry, Not A Winner";
		}
		Debug.Log(winnings);
	}
}
