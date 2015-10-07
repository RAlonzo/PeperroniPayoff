using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishLine : MonoBehaviour {

    public RacerSelection picks;

    public bool first;
    public bool second;
    public bool third;

    public int anyPayout;
    public int exactPayout;
    public int prize;
    public int modeToPlay;

    public bool raceFinish;

    public string[] standingNames;

    public Image winImage;
    public Text amountTxt;
    public Text winningTxt;

    public GameObject replayBttn;
    public GameObject exitBttn;


    float duration = 1.0f; // This will be your time in seconds.
    float smoothness = 0.02f;

    // Use this for initialization
    void Start()
    {
        anyPayout = 0;
        exactPayout = 0;
        prize = 0;
        modeToPlay = 1;
        raceFinish = false;
        first = false;
        second = false;
        third = false;
    }

	// Update is called once per frame
	void RaceFinish () {
        Mode(modeToPlay);
        Debug.Log(anyPayout);
        Debug.Log(exactPayout);
        Debug.Log(prize);
        StartCoroutine(LerpColor());
    }

    IEnumerator LerpColor()
    {
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.
        yield return new WaitForSeconds(1.3f);
        while (progress < 1)
        {
            winImage.color = Color.Lerp(Color.clear, Color.black, progress);
            amountTxt.color = Color.Lerp(Color.clear, Color.white, progress);
            winningTxt.color = Color.Lerp(Color.clear, Color.white, progress);
            progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        replayBttn.SetActive(true);
        exitBttn.SetActive(true);


        yield return true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("enter");
        if (coll.gameObject.tag == "0" || coll.gameObject.tag == "1"
            || coll.gameObject.tag == "2" || coll.gameObject.tag == "3"
            || coll.gameObject.tag == "4")
        {
            if (first == false)
            {
                standingNames[0] = coll.gameObject.tag;
                first = true;
            } else if (second == false)
            {
                standingNames[1] = coll.gameObject.tag;
                second = true;
            }
            else if(third == false)
            {
                standingNames[2] = coll.gameObject.tag;
                third = true;
                raceFinish = true;
                RaceFinish();
            }           
        }
    }

    public void selectMode(int index)
    {
        modeToPlay = index;
        Debug.Log(modeToPlay);
    }



    public void Mode(int index)
    {
        switch (index)
        {
            case 4:
                PayoutAny(1f);
                break;
            case 3:
                PayoutAny(.5f);
                break;
            case 2:
                PayoutExact(1f);
                break;
            case 1:
                PayoutExact(.5f);
                break;
        }
            
    }

    void PayoutExact(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            if (picks.racerHolder[i].ToString() == standingNames[i])
            {
                exactPayout++;
            }
        }

        if(exactPayout == 3 &&  amount == 0.5f)
        {
            prize = 250;
        }else if(exactPayout == 3 &&  amount == 1f)
        {
            prize = 125;
        }

        amountTxt.text = "$ " + prize.ToString() + " !";
    }


    void PayoutAny(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(picks.racerHolder[i].ToString() == standingNames[j])
                {
                    anyPayout++;
                }
            }
        }

        if (anyPayout == 2 && amount == 0.5f)
        {
            prize = 20;
        }
        else if (anyPayout == 2 && amount == 1f)
        {
            prize = 40;
        }
        else if (anyPayout == 3 && amount == 0.5f)
        {
            prize = 80;
        }
        else if (anyPayout == 3 && amount == 1f)
        {
            prize = 160;
        }

        amountTxt.text = "$ " + prize.ToString() + " !";
    }
    
}
