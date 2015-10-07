using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialStuff : MonoBehaviour {

	public Toggle DSA;
	public GameObject tutCanvas;

	public bool showAgain;

	private bool shouldIShowAgain;

	private int logIns;

	private bool firstTime;

	private int loginAttempts;

	// Use this for initialization
	void Awake () {
		shouldIShowAgain = PlayerPrefs.GetInt("ShowMessageAgain",0) > 0? true:false;
		loginAttempts = PlayerPrefs.GetInt("logins");
	}

	void Start()
	{

		//if(!shouldIShowAgain && loginAttempts > 0)
		//{
		//	tutCanvas.SetActive(false);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt("logins",logIns);
		//Debug.Log(loginAttempts);
//		if(DSA.isOn)
//		{
//			showAgain = false;
//
//			
//		}else{
//			showAgain = true;
//
//		}
	}

	public void HelpMe()
	{
		tutCanvas.SetActive(true);
	}

	public void ContinueToGame()
	{
		tutCanvas.SetActive(false);
		logIns++;
		PlayerPrefs.SetInt("ShowMessageAgain",showAgain?1:0);
	}
}
