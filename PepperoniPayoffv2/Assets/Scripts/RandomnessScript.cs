using UnityEngine;
using System.Collections;

public class RandomnessScript : MonoBehaviour {
	private int previousNumber;
	private int currentNumber;

	public int prize0,prize1,prize2,prize3,prize4,prize5,prize6,prize7,prize8;
	
	public int counter1;
	public int counter2;
	public int counter3;
	public int counter5;
	public int counter10;
	public int counter20;
	public int counter30;
	public int counter50;
	public int counter100;
	public int counter200;
	public int counter500;
	public int counter800;

	public bool loopOver;
	//private int[] numbers = new int[12];

	private int[] newNumbers = new int[9];

	public int[] numbersForMatrix = new int[9];

	private int rangeHeight;

	// Use this for initialization
	void Awake () {

		loopOver = false;
		//Quick Way
//		for (int i = 0; i <= numbers.Length; i++) {
//			numbers [i] = Random.Range (1, 12);
//		}


		rangeHeight = 101;
		//Intense Way
		for (int i = 0; i <= 8; i++) {
			newNumbers [i] = Random.Range (25, rangeHeight);
			CheckNumbers();

		}
	
	}


	
	// Update is called once per frame
	void Update () {

		//Debug.Log(numbersForMatrix[0]);
		Debugger ();
		SetUnderBox ();
	}
	void Debugger(){
		if(Input.GetKeyDown(KeyCode.H))
		{
			Debug.Log(numbersForMatrix[0]);
			Debug.Log(numbersForMatrix[1]);

		}
	}
	private void SetUnderBox(){
		//DoubleCheck();
		
		prize0 = numbersForMatrix [0];
		//prize0 = 800;
		prize1 = numbersForMatrix [1];
		prize2 = numbersForMatrix [2];
		prize3 = numbersForMatrix [3];
		prize4 = numbersForMatrix [4];
		prize5 = numbersForMatrix [5];
		prize6 = numbersForMatrix [6];
		prize7 = numbersForMatrix [7];
		prize8 = numbersForMatrix [8];


		if (loopOver) {
			StartCoroutine ("CheckAll");
			StopAllCoroutines();
			loopOver = false;
		}
	}

	IEnumerator CheckAll()
	{


		DoubleCheck ();
		yield return new WaitForSeconds(0);
	}

	private void ComparePrizes(int prizeToCompare)
	{
		if(prizeToCompare == 1)
			counter1 += 1;
		if(prizeToCompare == 2)
			counter2++;
		if(prizeToCompare == 3)
			counter3++;
		if(prizeToCompare == 5)
			counter5++;
		if(prizeToCompare == 10)
			counter10++;
		if(prizeToCompare == 20)
			counter20++;
		if(prizeToCompare == 30)
			counter30++;
		if(prizeToCompare == 50)
			counter50++;
		if(prizeToCompare == 100)
			counter100++;
		if(prizeToCompare == 200)
			counter200++;
		if(prizeToCompare == 500)
			counter500++;
		if(prizeToCompare == 800)
			counter800++;
	}
	private void DoubleCheck()
	{
		for (int o = 0; o <= 8; o++) {
			if(numbersForMatrix[o] == 1)
				counter1++;
			if(numbersForMatrix[o] == 2)
				counter2++;
			if(numbersForMatrix[o] == 3)
				counter3++;
			if(numbersForMatrix[o] == 5)
				counter5++;
			if(numbersForMatrix[o] == 10)
				counter10++;
			if(numbersForMatrix[o] == 20)
				counter20++;
			if(numbersForMatrix[o] == 30)
				counter30++;
			if(numbersForMatrix[o] == 50)
				counter50++;
			if(numbersForMatrix[o] == 100)
				counter100++;
			if(numbersForMatrix[o] == 200)
				counter200++;
			if(numbersForMatrix[o] == 500)
				counter500++;
			if(numbersForMatrix[o] == 800)
				counter800++;



		}
	}

	private void CheckNumbers()
	{
		for (int o = 0; o<= 8; o++){
			//Probability-------------------------------------
			if (newNumbers [o] <= 25 && newNumbers[o] >= 0) {
				numbersForMatrix [o] = 1;
			}
			else if(newNumbers[o] <= 30 && newNumbers[o] > 25){
				numbersForMatrix[o] = 2;
			}
			else if(newNumbers[o] <= 58 && newNumbers[o] > 55){
				numbersForMatrix[o] = 3;
			}
			else if(newNumbers[o] <= 63 && newNumbers[o] > 60){
				numbersForMatrix[o] = 5;
			}
			else if(newNumbers[o] <= 73 && newNumbers[o] > 70){
				numbersForMatrix[o] = 10;
			}
			else if(newNumbers[o] <= 78 && newNumbers[o] > 75){
				numbersForMatrix[o] = 20;
			}
			else if(newNumbers[o] <= 83 && newNumbers[o] > 80){
				numbersForMatrix[o] = 30;
			}
			else if(newNumbers[o] <= 86 && newNumbers[o] > 83){
				numbersForMatrix[o] = 50;
			}
			else if(newNumbers[o] <= 88 && newNumbers[o] > 86){
				numbersForMatrix[o] = 100;
			}
			else if(newNumbers[o] <= 91 && newNumbers[o] > 88){
				numbersForMatrix[o] = 200;
			}
			else if(newNumbers[o] <= 95 && newNumbers[o] > 91){
				numbersForMatrix[o] = 500;
			}
			else if(newNumbers[o] <= 96 && newNumbers[o] > 95){
				numbersForMatrix[o] = 800;
			}else{
				newNumbers[o] = Random.Range(30,80);
				Debug.Log("Generated a : " + numbersForMatrix[o]);
			}
			if(counter500 > 2 || counter800 > 2)
			{
				rangeHeight = 90;
			}


			for(int j = o+1; j <= 8 ; j++)
			{
				if(numbersForMatrix[j] == numbersForMatrix[o])
				{
					newNumbers[o] = Random.Range(20, rangeHeight);
				}
			}

			if(o >= 1){
			if(numbersForMatrix[o-1] == numbersForMatrix[o]){
				Debug.Log("shuffle");
				//numbersForMatrix[o] = Random.Range(1, 4); 
				newNumbers[o] = Random.Range(20, 70);
			}
			}
			//DoubleCheck(o);
		}
		//DO STUFF HERE
		loopOver = true;
	}
}
