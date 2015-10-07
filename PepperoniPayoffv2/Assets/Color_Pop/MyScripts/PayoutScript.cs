using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PayoutScript : MonoBehaviour {
    public GameObject payoutPanal;
    public Text newNums;
    public Text oldNums;

    public Text newNums2;
    public Text oldNums2;

    public Text newNums3;
    public Text oldNums3;

    public Text newNums4;
    public Text oldNums4;

    public Text newNums5;
    public Text oldNumbers5;

    public

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TogglePayoutPanal(GameObject objToToggle)
    {
        if(!objToToggle.activeSelf)
        {
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }

    public void TogglePayoutPanalWithText(GameObject objToToggle)
    {
        //oldNums.text = GameObject.Find("TextTic" + ticNum.ToString()).GetComponent<Text>().text;
        if (!objToToggle.activeSelf)
        {
            newNums.text = oldNums.text.ToString();
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }
    public void TogglePayoutPanalWithText2(GameObject objToToggle)
    {
        //oldNums.text = GameObject.Find("TextTic" + ticNum.ToString()).GetComponent<Text>().text;
        if (!objToToggle.activeSelf)
        {
            newNums2.text = oldNums2.text.ToString();
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }

    public void TogglePayoutPanalWithText3(GameObject objToToggle)
    {
        //oldNums.text = GameObject.Find("TextTic" + ticNum.ToString()).GetComponent<Text>().text;
        if (!objToToggle.activeSelf)
        {
            newNums3.text = oldNums3.text.ToString();
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }

    public void TogglePayoutPanalWithText4(GameObject objToToggle)
    {
        //oldNums.text = GameObject.Find("TextTic" + ticNum.ToString()).GetComponent<Text>().text;
        if (!objToToggle.activeSelf)
        {
            newNums4.text = oldNums4.text.ToString();
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }

    public void TogglePayoutPanalWithText5(GameObject objToToggle)
    {
        //oldNums.text = GameObject.Find("TextTic" + ticNum.ToString()).GetComponent<Text>().text;
        if (!objToToggle.activeSelf)
        {
            newNums5.text = oldNumbers5.text.ToString();
            objToToggle.SetActive(true);
        }
        else
        {
            objToToggle.SetActive(false);
        }
    }

}
