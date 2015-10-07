using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DartManager : MonoBehaviour {
	private int darts;
    private int kDarts;
    public SetGrid redoGrid;
	public ChooseGameScript chooseGameScript;

    public List<Button> dartsUI = new List<Button>();
    private List<Button> activeDart = new List<Button>();
	// Use this for initialization
	void Start () {
		darts = 0;
        CheckDarts();
	}
	public void SetDarts(int amountOfDarts)
	{
		darts = amountOfDarts;
        kDarts = amountOfDarts;
	}
	// Update is called once per frame
	void Update () {
        //Debug.Log (darts);
        //CheckDarts();
        //CheckActiveDarts();
	}

    public void CheckDarts()
    {
        foreach(Button dart in dartsUI)
        {
            dart.interactable = false;
        }
        for (int i = 0; i < this.GetDarts(); i++)
        {
            dartsUI[i].interactable = true;
            //activeDart.Add(dartsUI[i]);
        }
    }

    private void CheckActiveDarts()
    {
        foreach(Button dart in activeDart)
        {
            dart.interactable = true;
        }
    }
    public void SubtractDart()
	{
		darts--;
        CheckDarts();
	}
	public int GetDarts(){
		return darts;
	}
    public int GetInitDarts()
    {
        return kDarts;
    }
    public void ResetDarts()
    {
        redoGrid.BuildGrid();
        darts = kDarts;
        CheckDarts();
    }
    public void ReplayDarts()
    {
        redoGrid.ReplayGrid();
        darts = kDarts;
    }
}
