using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	//classes
	public AutoGenerationManager GenerateNumbers;

	private const float kSecondsInMinute = 60.0f;
	public int kMinutesTillNewGame = 0;
	private int minutes;
	private float seconds;

	public Text timerText;

    public GameObject loseScreen;

	// Use this for initialization
	void Start () {
		seconds = kSecondsInMinute;
		minutes = kMinutesTillNewGame - 1;
		GenerateNums(40);
	}
	
	// Update is called once per frame
	void Update () {
		StartTimer();
	}

    public void ResetTimer()
    {
        minutes = 2;
        seconds = 59;
    }

	void StartTimer()
	{
		seconds -= Time.deltaTime;
		int cleanSeconds = (int)(seconds);
		
		if(seconds < 0)
		{
			minutes--;
			seconds = kSecondsInMinute; 
		}
		
		if(cleanSeconds >= 10)
		{
			timerText.text = minutes.ToString() + ":" + cleanSeconds.ToString();
		}else{
			timerText.text = minutes.ToString() + ":0" + cleanSeconds.ToString();
		}
		if(cleanSeconds <= 30 && minutes == 0)
		{
			timerText.color = Color.yellow;
		}
		if(minutes < 0)
		{
			minutes = kMinutesTillNewGame;
			seconds = kSecondsInMinute;
			timerText.color = Color.white;
            loseScreen.SetActive(true);
			//GenerateNums(40);
		}
	}
	void GenerateNums(int highest)
	{
		GenerateNumbers.GenerateNumbers(highest);
		
	}
}
