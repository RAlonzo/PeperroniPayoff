using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Matches : MonoBehaviour {

    public RandomnessScript Numbers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckSpotters();
	}



    void CheckSpotters()
    {
        if (Numbers.counter1 > 0)
        {
            ToggleSpotters("1_", Numbers.counter1);
        }
        if (Numbers.counter2 > 0)
        {
            ToggleSpotters("2_", Numbers.counter2);
        }
        if (Numbers.counter3 > 0)
        {
            ToggleSpotters("3_", Numbers.counter3);
        }
        if (Numbers.counter5 > 0)
        {
            ToggleSpotters("5_", Numbers.counter5);
        }
        if (Numbers.counter10 > 0)
        {
            ToggleSpotters("10_", Numbers.counter10);
        }
        if (Numbers.counter20 > 0)
        {
            ToggleSpotters("20_", Numbers.counter20);
        }
        if (Numbers.counter50 > 0)
        {
            ToggleSpotters("50_", Numbers.counter50);
        }
        if (Numbers.counter100 > 0)
        {
            ToggleSpotters("100_", Numbers.counter100);
        }
        if (Numbers.counter100 > 0)
        {
            ToggleSpotters("100_", Numbers.counter100);
        }
        if (Numbers.counter200 > 0)
        {
            ToggleSpotters("200_", Numbers.counter200);
        }
        if (Numbers.counter500 > 0)
        {
            ToggleSpotters("500_", Numbers.counter500);
        }
    }

    void ToggleSpotters(string NumUnderscore, int counter)
    {
        GameObject.Find(NumUnderscore + counter.ToString()).GetComponent<Image>().color = Color.white;
    }

}
