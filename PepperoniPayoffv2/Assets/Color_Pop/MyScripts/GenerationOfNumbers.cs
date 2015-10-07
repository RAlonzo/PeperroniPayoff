using UnityEngine;
using System.Collections;

public class GenerationOfNumbers : MonoBehaviour {


    private int maxNum;
    private int kMaxNum;

    private bool alreadyBonus;

	// Use this for initialization
	void Start () {
        maxNum = 45;
        kMaxNum = 45;
        alreadyBonus = false;
	}

	public bool CheckAlreadyBonus()
    {
        return alreadyBonus;
    }
    public void SetAlreadyBonus(bool bonusYet)
    {
        alreadyBonus = bonusYet;
    }
	public int GetMaxNum()
    {
        return maxNum;
    }
    public void SetMaxNum(int newMax)
    {
        maxNum = newMax;
    }
    public int GetInitMaxNum()
    {
        return kMaxNum;
    }
    public void ResetMaxNum()
    {
        maxNum = kMaxNum;
    }
}
