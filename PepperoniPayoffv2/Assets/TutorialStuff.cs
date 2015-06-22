using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialStuff : MonoBehaviour {

	public Toggle DSA;
	public GameObject tutCanvas;

	public bool showAgain;

	private bool shouldIShowAgain;

	// Use this for initialization
	void Awake () {
		shouldIShowAgain = PlayerPrefs.GetInt("ShowMessageAgain",0) > 0? true:false;
	}

	void Start()
	{
		if(!shouldIShowAgain)
		{
			tutCanvas.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(DSA.isOn)
		{
			showAgain = false;
		}else{
			showAgain = true;
		}
	}

	public void HelpMe()
	{
		tutCanvas.SetActive(true);
	}

	public void ContinueToGame()
	{
		tutCanvas.SetActive(false);
		PlayerPrefs.SetInt("ShowMessageAgain",showAgain?1:0);
	}
}
