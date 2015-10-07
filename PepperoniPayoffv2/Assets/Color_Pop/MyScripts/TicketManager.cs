using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class TicketManager : MonoBehaviour {
	private int tickets;
    private int kTix;
    public GameObject loseScreen;
	public List<Button> tix = new List<Button>();

    public BonusManager bonusMan;
	public ChooseGameScript gameManager;
    public bool readyToEnd;
	// Use this for initialization
	void Start () {
		tickets = 0;
        kTix = 0;
        readyToEnd = false;
	}
	void Update()
	{
		CheckTickets();
	}
	private void CheckTickets()
	{
		for(int i = 0; i < this.GetTix(); i++)
		{
			tix[i].interactable = true;
		}
	}
	public void SetTix(int tix)
	{
		tickets = tix;
        kTix = tix;
	}
	public int GetTix()
	{
		return tickets;
	}
    public int GetInitTix()
    {
        return kTix;
    }
    public void OutOfTicketsLOSE()
    {
        if (!bonusMan.startBonusGame)
        {
            StartCoroutine(Lose());
        }else
        {
            readyToEnd = true;
        }

    }
    public void OutOfTicketsLOSEAfterBonus()
    {
        if (!bonusMan.startBonusGame)
        {
            StartCoroutine(LoseAfterBonus());
        }

    }
    IEnumerator LoseAfterBonus()
    {
        yield return new WaitForSeconds(1.5f);
        loseScreen.SetActive(true);
        yield return 0;
    }
    IEnumerator Lose()
    {
        yield return new WaitForSeconds(1.5f);
        loseScreen.SetActive(true);
        yield return 0;
    }
}
