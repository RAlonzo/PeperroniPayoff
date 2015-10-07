using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoseScript : MonoBehaviour {

    public Text matches;
    public NumberManager numMan;
    public DartManager dartMan;

    public Text winOrLose;

    public Text winnings;


    public Text tic1;
    public Text tic2;
    public Text tic3;
    public Text tic4;
    public Text tic5;

    public ThrowRandomDart checkMultiplier;

    public List<GameObject> stuffToToggle = new List<GameObject>();


    public class WinningStuff
    {
        //this class will allow you to check if and how much people will win
        private int numOfDarts;
        private int actualPrize;
        private string winLoseStrng;
        private Color winLoseColor;
        private string winString = "WINNER!";
        private string loseString = "Try Again";

        private bool win;
        public WinningStuff()
        {
            winLoseColor = Color.green;
        }
        public void SetDarts(int drts)
        {
            numOfDarts = drts;
        }

        public bool GetWin()
        {
            return win;
        }
        public Color GetColor()
        {
            return winLoseColor;
        }

        public string GetWinLoseString()
        {
            return winLoseStrng;
        }
        public int GetWinnings(int matches)
        {
            
            //check how much you win
            switch (numOfDarts)
            {
                case 3:
                    if (matches == 0)
                    {
                        actualPrize = 0;
                        winLoseStrng = loseString;
                        winLoseColor = Color.red;
                        win = false;
                    }
                    if (matches == 1)
                    {
                        actualPrize = 0;
                        winLoseStrng = loseString;
                        win = false;
                        winLoseColor = Color.red;
                    }
                    if (matches == 2)
                    {
                        actualPrize = 1;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    if(matches == 3)
                    {
                        actualPrize = 5;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    break;
                case 4:
                    if (matches == 0)
                    {
                        actualPrize = 0;
                        winLoseStrng = loseString;
                        win = false;
                        winLoseColor = Color.red;
                    }
                    else if (matches == 1)
                    {
                        actualPrize = 0;
                        winLoseStrng = loseString;
                        win = false;
                        winLoseColor = Color.red;
                    }
                    else if (matches == 2)
                    {
                        actualPrize = 1;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 3)
                    {
                        actualPrize = 2;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 4)
                    {
                        actualPrize = 25;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    break;
                case 5:
                    if (matches == 0)
                    {
                        actualPrize = 0;
                        winLoseStrng = loseString;
                        win = false;
                        winLoseColor = Color.red;
                    }
                    else if (matches == 1)
                    {
                        actualPrize = 1;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 2)
                    {
                        actualPrize = 2;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 3)
                    {
                        actualPrize = 10;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 4)
                    {
                        actualPrize = 20;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    else if (matches == 5)
                    {
                        actualPrize = 50;
                        winLoseStrng = winString;
                        win = true;
                        winLoseColor = Color.green;
                    }
                    break;

            }
            return actualPrize;
        }

    }

    WinningStuff winningstuff = new WinningStuff();

    // Use this for initialization
    void Start () {
        dartMan = GameObject.Find("ScriptHolder").GetComponent<DartManager>();  
	}
	
	// Update is called once per frame
	void Update () {
        
        winningstuff.SetDarts(dartMan.GetInitDarts());          //this tells the Winnings class how many darts there were at the beginning
        matches.text = numMan.GetNumbersMatched().ToString();   //how many matches were there?

        winnings.text = "$" + (winningstuff.GetWinnings(numMan.GetNumbersMatched())*checkMultiplier.multiplier).ToString();  //Output the winnings

        winOrLose.color = winningstuff.GetColor();              //win or lose color for the winner/loser text
        winOrLose.text = winningstuff.GetWinLoseString();       //display the text for winner/Loser on screen

        if(!winningstuff.GetWin())
        {
            foreach(GameObject obj in stuffToToggle)
            {
                obj.SetActive(false);
            }
        }else
        {
            foreach(GameObject obj in stuffToToggle)
            {
                obj.SetActive(true);
            }
        }
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}

    //This is when you hit replay
    public void Replay()
    {
        //What happens when the replay button is pressed
        dartMan.ReplayDarts();
        numMan.OutOfDarts = false;
        numMan.OutOfTix = false;
        tic1.text = "";
        tic2.text = "";
        tic3.text = "";
        tic4.text = "";
        tic5.text = "";
        numMan.numbersMatched = 0;
        //numMan.ResetText();
        if (!numMan.OutOfTix && !numMan.OutOfTix)
        {
            numMan.i = 0;
            numMan.numbers.Clear();
            numMan.ticketNumber = 1;
            gameObject.SetActive(false);
        }
        
        //
    }



}
