using UnityEngine;
using System.Collections;

public class PlacePrizes : MonoBehaviour {
	
	public RandomnessScript prizes;

	public GameObject particlePrefab;

	private GameObject number;
	
	
	private GameObject newNumber;
	
	private GameObject newTarget;
	
	private GameObject newEndtarget;
	
	public GameObject blocker;

	private int maxGenNum;
	private int minGenNum;

	private GameObject[] numOrder = new GameObject[9];
	private GameObject[] tarOrder = new GameObject[9];
	
	private bool doneWithGen;

	public int highestGeneration;
	public int lowestGeneration;

	public BoxMoverScript MoveBoxes;

	public Winnings EndStuff;

	bool doLerps;
	bool lerp;
	bool secLerp;

	int index;



	public bool inTransit0;
	public bool inTransit1;

	private float timer;
	private bool startTimer;
	private bool readyForNext;
	
	// Use this for initialization
	void Start () {
		//highestGeneration = 0;
		timer = 3.0f;
		startTimer = false;
		readyForNext = false;
        highestGeneration = 50;
        lowestGeneration = 1;
        //DELETe THIS
        maxGenNum = 3000;
		minGenNum = -3000;
		doneWithGen = false;
		index = -1;
		inTransit0 = false;
		inTransit1 = false;
		lerp = false;
		blocker.SetActive (false);
		newNumber = null;
		newTarget = null;
		newEndtarget = null;
	}

	void Update()
	{

		if(startTimer)
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				readyForNext = true;
				startTimer = false;
			}
		}
		if(prizes.counter800 > 1)
		{
			maxGenNum = 1600;
		}
		if(prizes.counter500 > 1)
		{
			maxGenNum = 1600;
		}
		if(prizes.counter200 > 1)
		{
			maxGenNum = 1600;
		}if(prizes.counter100 > 1)
		{
			maxGenNum = 1600;
		}
		if(prizes.counter1 > 1)
		{
			minGenNum = 300;
		}
		if(prizes.counter1 > 2)
		{
			minGenNum = 601;
		}

		if(prizes.counter2 > 1)
		{
			minGenNum = 900;
		}
		if(prizes.counter3 > 1)
		{
			minGenNum = 1150;
		}
		if(prizes.counter5 > 1)
		{
			minGenNum = 1600;
		}
	}


	public void PizzasToGo()
	{

		StartCoroutine(CheckAll());
		for(int j = 0; j < 6; j++)
		{
			//DoubleCheck(j);
			Debug.Log("Checked under " + j);
		}
			
		
	}

	public IEnumerator CheckAll()
	{
		for(int i = 0; i < 6; i++)
		{
			AUTOCheckBox0(i);
			//MoveBoxes.BoxFly(i);
			EndStuff.SubtractBoxesRemaining();
			EndStuff.CheckForWinners();
			yield return(500000);
		}

	}


	public void CheckBox0(int boxNumber)
	{
		//The script finds the proper gameobject by its self so that we don't need to drag in.
		//When the button is pressed, it calls the number of the pizza box, which tells the code which placement of the numbers to use
		//************************************************************************************************
		//***IMPORTANT : DO NOT change the names of anything that has to do with numbers in heirarchy.****
		//StopAllCoroutines();
		index++;
		prizes.numbersForMatrix[boxNumber] = GeneratePrize();

		//DELET THIS TEST
		//prizes.numbersForMatrix[boxNumber] = 800;
		
		//delete end

		if(doneWithGen)
		{
		newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
		newTarget = GameObject.Find("0" + prizes.numbersForMatrix[boxNumber] + "Target");
		newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
		numOrder[index] = newNumber;
		tarOrder[index] = newEndtarget;
		if(newNumber == GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text"))
		{
			StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
			Instantiate(particlePrefab,newNumber.transform.position,Quaternion.identity);	
		}
			DoubleCheck(boxNumber);
		}
		}

	public void AUTOCheckBox0(int boxNumber)
	{
		//The script finds the proper gameobject by its self so that we don't need to drag in.
		//When the button is pressed, it calls the number of the pizza box, which tells the code which placement of the numbers to use
		//************************************************************************************************
		//***IMPORTANT : DO NOT change the names of anything that has to do with numbers in heirarchy.****
		//StopAllCoroutines();
		index++;
		prizes.numbersForMatrix[boxNumber] = GeneratePrize();

		//TEST DELETE!!!
		//prizes.numbersForMatrix[boxNumber] = 800;
		
		
		if(doneWithGen)
		{
			newNumber = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text");
			newTarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
			newEndtarget = GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber]+ "endTarget");
			numOrder[index] = newNumber;
			tarOrder[index] = newEndtarget;
			if(newNumber == GameObject.Find(boxNumber+""+prizes.numbersForMatrix[boxNumber] + "Text"))
			{
				StartCoroutine("LerpPosition");		//Start the lerp once the button is pressed and the gameobjects have the right instances
				Instantiate(particlePrefab,newNumber.transform.position,Quaternion.identity);	
			}
			DoubleCheck(boxNumber);
		}
	}

	//Added
	private void DoubleCheck(int boxNum)
	{
		//How Many Of Each Number is there?
		//This allows multiple prizes.
		//We if theres a match of 3, add that quantity to the prize counter!

			if(prizes.numbersForMatrix[boxNum] == 1)
				prizes.counter1++;
			if(prizes.numbersForMatrix[boxNum] == 2)
				prizes.counter2++;
			if(prizes.numbersForMatrix[boxNum] == 3)
				prizes.counter3++;
			if(prizes.numbersForMatrix[boxNum] == 5)
				prizes.counter5++;
			if(prizes.numbersForMatrix[boxNum] == 10)
				prizes.counter10++;
			if(prizes.numbersForMatrix[boxNum] == 20)
				prizes.counter20++;
			if(prizes.numbersForMatrix[boxNum] == 30)
				prizes.counter30++;
			if(prizes.numbersForMatrix[boxNum] == 50)
				prizes.counter50++;
			if(prizes.numbersForMatrix[boxNum] == 100)
				prizes.counter100++;
			if(prizes.numbersForMatrix[boxNum] == 200)
				prizes.counter200++;
			if(prizes.numbersForMatrix[boxNum] == 500)
				prizes.counter500++;
			if(prizes.numbersForMatrix[boxNum] == 800)
				prizes.counter800++;
			
			
			

	}

	//EndAdd




	int GeneratePrize()
	{
		//let some people win ;)
		int seed;
		int actualPrize = 0;
		seed = Random.Range(minGenNum, maxGenNum);
		doneWithGen = false;
		if(seed <= 600)
		{
			actualPrize = lowestGeneration;
		}
		else if(seed <= 1000 && seed > 600)
		{
			if(lowestGeneration > 2)
			{
				actualPrize = lowestGeneration;
			}else
				actualPrize = 2;
		}
		else if(seed <= 1300 && seed > 1000)
		{
			if(lowestGeneration > 3)
			{
				actualPrize = lowestGeneration;
			}else
				actualPrize = 3;
		}
		else if(seed <= 1500 && seed > 1300)
		{
			actualPrize = 5;
		}
		else if(seed <= 1600 && seed > 1500)
		{
			actualPrize = 10;
		}
		else if(seed <= 1650 && seed > 1600)
		{
			actualPrize = 20;
		}
		else if(seed <= 1700 && seed > 1650)
		{
			actualPrize = 30;
		}
		else if(seed <= 1730 && seed > 1700)
		{
			actualPrize = 50;
		}
		else if(seed <= 1750 && seed > 1730)
		{
			if(lowestGeneration == 100)
			{
				actualPrize = 50;
			}else
			actualPrize = 100;
		}
		else if(seed <= 1760 && seed > 1750)
		{
			actualPrize = 200;
		}
		else if(seed <= 1765 && seed > 1760)
		{
			if(lowestGeneration > 200)
			{
				actualPrize = 200;
			}else
			actualPrize = 500;
		}
		else if(seed <= 3000 && seed > 1765)
		{
			actualPrize = highestGeneration;

		}
		//Debug.Log(seed);
		doneWithGen = true; //to check when the generation is done.
		return actualPrize; // return what the generated number was.
	}

	IEnumerator LerpPosition()
	{

		if(newNumber == null)
		{
			newNumber = GameObject.Find(0+""+prizes.numbersForMatrix[0] + "Text"); //This is the number that will fly up to the screen
		}
		if(newTarget == null)
		{
			newTarget = GameObject.Find("0" + prizes.numbersForMatrix[0] + "Target");	// this is where on the screen that the number is going to fly
		}
		if(newEndtarget == null)
		{
			newEndtarget = GameObject.Find(0+""+prizes.numbersForMatrix[0]+ "endTarget");	//This is the target back on the table
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
			yield return new WaitForSeconds(.000000001f); //if changed this number will screw up the timing.
			//yield return new WaitForSeconds(.0002f);


		}
			Destroy(GameObject.Find("Star_Particle(Clone)"));
		
		inTransit0 = false;
		blocker.SetActive (false);
		secLerp = false;
		progress = 0;
		StopAllCoroutines (); //Just to make sure there is nothing slowing down the game in the background
		yield return true;
	}


	
	
	
}
