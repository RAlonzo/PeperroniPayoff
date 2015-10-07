using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class AutoGenerationManager : MonoBehaviour {
    List<int> RandomNumbers = new List<int>();

	public int firstNumber;
	public int secondNumber;
	public int thirdNumber;
	public int fourthNumber;
	public int fifthNumber;

	public Text first;
	public Text second;
	public Text third;
	public Text fourth;
	public Text fifth;
	

	public void GenerateNumbers(int highestAllowedGeneration)
	{
		firstNumber = Random.Range(1, highestAllowedGeneration);
		secondNumber = Random.Range(1, highestAllowedGeneration);
		thirdNumber = Random.Range(1, highestAllowedGeneration);
		fourthNumber = Random.Range(1, highestAllowedGeneration);
		fifthNumber = Random.Range(1, highestAllowedGeneration);


        if (!RandomNumbers.Contains(firstNumber))
        {
            RandomNumbers.Add(firstNumber);
        }else
        {
            firstNumber++;
        }
        if (!RandomNumbers.Contains(secondNumber))
        {
            RandomNumbers.Add(secondNumber);
        }
        else
        {
            secondNumber++;
        }
        if (!RandomNumbers.Contains(thirdNumber))
        {
            RandomNumbers.Add(thirdNumber);
        }
        else
        {
            thirdNumber++;
        }
        if (!RandomNumbers.Contains(fourthNumber))
        {
            RandomNumbers.Add(fourthNumber);
        }
        else
        {
            fourthNumber++;
        }
        if (!RandomNumbers.Contains(fifthNumber))
        {
            RandomNumbers.Add(fifthNumber);
        }
        else
        {
            fifthNumber++;
        }




        first.text = firstNumber.ToString();
		second.text = secondNumber.ToString();
		third.text = thirdNumber.ToString();
		fourth.text = fourthNumber.ToString();
		fifth.text = fifthNumber.ToString();
		
	}

}
