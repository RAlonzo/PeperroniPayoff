using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour {

	public List <int> numbers = new List<int>();
	private AutoGenerationManager numsToMatch;
	private bool incrimentScore;
	public int numbersMatched;
	private bool firstSpot = false;
	private bool secSpot = false;
	private bool thirSpot = false;
	private bool fourSpot = false;
	private bool fifSpot = false;
	public bool OutOfDarts;
    public bool OutOfTix;
	public DartManager dartMan;
    public TicketManager tixMan;

    public int maxNumberGeneration;


    public int i;

    public int ticketNumber;

    public Text TicOneTxt;


	// Use this for initialization
	void Start () {
		numbersMatched = 0;
		numsToMatch = GetComponent<AutoGenerationManager> ();
		OutOfDarts = false;
        OutOfTix = false;
		firstSpot = false;
		secSpot = false;
		thirSpot = false;
		fourSpot = false;
		fifSpot = false;
        i = 0;
        ticketNumber = 1;


	}
    void Update()
    {
        TicOneTxt = GameObject.Find("TextTic" + ticketNumber.ToString()).GetComponent<Text>();
        
    }

    public void Replay()
    {
        numsToMatch.first.color = Color.white;
        numsToMatch.second.color = Color.white;
        numsToMatch.third.color = Color.white;
        numsToMatch.fourth.color = Color.white;
        numsToMatch.fifth.color = Color.white;

    }
    public int GetNumbersMatched()
    {
        return numbersMatched;
    }

	public void CheckMatches(){
        if (ticketNumber >= tixMan.GetInitTix() && dartMan.GetDarts() <= 1)
        {
            OutOfTix = true;
            tixMan.OutOfTicketsLOSE();
        }
        TicOneTxt.text += numbers[i];
        TicOneTxt.text += "-";
        if (!OutOfTix)
        {
            i++;
        }
		if(!OutOfDarts)
		{
			if(dartMan.GetDarts() <= 1)
			{
                OutOfDarts = true;
                ticketNumber++;
                dartMan.ResetDarts();
			}else{
				dartMan.SubtractDart ();
			}
		}
		if(numbers.Contains(numsToMatch.firstNumber)){
			numsToMatch.first.color = Color.green;
			if(!firstSpot)
			{
				numbersMatched++;
				firstSpot = true;
			}
		}
        else numsToMatch.first.color = Color.white;
        if (numbers.Contains(numsToMatch.secondNumber)){
			numsToMatch.second.color = Color.green;
			if(!secSpot)
			{
				numbersMatched++;
				secSpot = true;
			}
		}
        else numsToMatch.second.color = Color.white;
        if (numbers.Contains(numsToMatch.thirdNumber)){
			numsToMatch.third.color = Color.green;
			if(!thirSpot)
			{
				numbersMatched++;
				thirSpot = true;
			}
		}
        else numsToMatch.third.color = Color.white;
        if (numbers.Contains(numsToMatch.fourthNumber)){
			numsToMatch.fourth.color = Color.green;
			if(!fourSpot)
			{
				numbersMatched++;
				fourSpot = true;	
			}
		}
        else numsToMatch.fourth.color = Color.white;
        if (numbers.Contains(numsToMatch.fifthNumber))
        {
            numsToMatch.fifth.color = Color.green;
            if (!fifSpot)
            {
                numbersMatched++;
                fifSpot = true;
            }
        }
        else numsToMatch.fifth.color = Color.white;
	}

}
