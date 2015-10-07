using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ChooseGameScript : MonoBehaviour {

	[Serializable]
	public class Count
	{
		private int maximum;
		private int minimum;
		public Count(int min, int max)
		{
			maximum = max;
			minimum = min;
		}
		public int GetMin()
		{
			return minimum;
		}
		public int GetMax()
		{
			return maximum;
		}
	}

    public class Money
    {
        private int amountDue;
        private int max;
        public Money(int required, int setmax)
        {
            amountDue = required;
            max = setmax;
        }
        public void Max()
        {
            amountDue = max;
        }
        public int GetMoneyDue()
        {
            return amountDue;
        }
        public void MoreMoney()
        {
            amountDue++;
        }
        public void LessMoney()
        {
            amountDue--;
        }

        public int GetTotal(int tickets)
        {

            return amountDue * tickets;
        }
        public string GetTotalInStringForm(int tickets)
        {
            string amnt = "$" + GetTotal(tickets).ToString();
            return amnt;
        }

    }

    public DartManager PopScript;
	public TicketManager TicketManager;

	//Dart Stuff
	public int amntOfDarts;

	public Button addDartsBttn;
	public Button subtractDartsBttn;
	public Button maxDarts;
	public Text amntDartsTxt;

	//Ticket Stuff
	private int amntOfTix;

	public Button addTixBttn;
	public Button subtractTixBttn;
	public Button maxTickets;
	public Text amntOfTixTxt;

	public Count darts = new Count(3,5);
	public Count tickets = new Count(1,5);
    public Money money = new Money(1,3);

    //private int amountDue;
    public Text moneyText;

    

	// Use this for initialization
	void Start () {
		amntOfDarts = darts.GetMin();
		amntOfTix = 1;

	}
	
	// Update is called once per frame
	void Update () {
		DartStuff ();
		TicketStuff ();
        MoneyStuff();
	}
	public void SetAmountOfDarts()
	{
		PopScript.SetDarts (amntOfDarts);
	}
	public void SetAmountOfTix()
	{
		TicketManager.SetTix(amntOfTix);
		//Debug.Log(TicketManager.GetTix());
	}
    //Money Stuff
    private void MoneyStuff()
    {
        moneyText.text = money.GetTotalInStringForm(amntOfTix);
    }
	//Dart Stuff
	private void DartStuff()
	{
		amntDartsTxt.text = amntOfDarts.ToString();
		if(amntOfDarts <= darts.GetMin()){
			subtractDartsBttn.interactable = false;
		}else{
			subtractDartsBttn.interactable = true;
		}
		if(amntOfDarts >= darts.GetMax()){
			addDartsBttn.interactable = false;
			maxDarts.interactable = false;

		}else{
			addDartsBttn.interactable = true;
			maxDarts.interactable = true;
		}
	}

	public void AddDarts()
	{
		amntOfDarts++;
        money.MoreMoney();
	}
	public void SubtractDarts()
	{
		amntOfDarts--;
        money.LessMoney();
	}

	public void DartsMaxBet()
	{
		amntOfDarts = darts.GetMax ();
        money.Max();
	}
	//End Dart Stuff

	//Ticket Stuff
	private void TicketStuff()
	{
		amntOfTixTxt.text = amntOfTix.ToString();
		if(amntOfTix <= tickets.GetMin()){
			subtractTixBttn.interactable = false;
		}else{
			subtractTixBttn.interactable = true;
		}
		if(amntOfTix >= tickets.GetMax()){
			addTixBttn.interactable = false;
			maxTickets.interactable = false;
		}else{
			addTixBttn.interactable = true;
			maxTickets.interactable = true;
		}
	}
	public void TixMaxBet()
	{
		amntOfTix = tickets.GetMax ();
	}
	public void AddTix()
	{
		amntOfTix++;
	}
	public void SubtractTix()
	{
		amntOfTix--;
	}
}
