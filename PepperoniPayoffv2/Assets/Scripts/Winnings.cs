using UnityEngine;
using System.Collections;

public class Winnings : MonoBehaviour {

	private int winnings;
	public RandomnessScript Counters;

	// Use this for initialization
	void Start () {
		winnings = 0;
	}
	
	// Update is called once per frame
	void Update () {

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
		Debug.Log(winnings);
	}
}
