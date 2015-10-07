using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum GAME_STATES{menu,game,end};
	GAME_STATES currentState;

	public GameObject manager;

	private float timer;
	

	public static GameManager i; 

	void OnAwake()
	{
			DontDestroyOnLoad(GameObject.Find("GAME_MANAGER"));
	}

	// Use this for initialization
	void Start () {
		Debug.Log(currentState);
		timer = 0;
		currentState = GAME_STATES.menu;

	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad(GameObject.Find("GAME_MANAGER"));
		CheckGamePace();
		if(currentState == GAME_STATES.menu)
		{
			Debug.Log("MENU");
		}
		else if(currentState == GAME_STATES.game)
		{

			//Debug.Log("GAME");
			//timer += Time.deltaTime;
			int gameTime = (int)(timer);
//			Debug.Log(gameTime);
		}
		else if(currentState == GAME_STATES.end)
		{
			Debug.Log("END");
			Destroy(GameObject.Find("GAME_MANAGER"));
		}
	}

	void CheckGamePace()
	{
		if(Application.loadedLevel == 0)
		{
			currentState = GAME_STATES.menu;
		}
		else if(Application.loadedLevel == 3)
		{
			currentState = GAME_STATES.game;
		}
	}

	public void StartGame()
	{
		currentState = GAME_STATES.game;
		Debug.Log(currentState);
	}

	public void EndScreen()
	{
		currentState = GAME_STATES.end;
		Destroy(GameObject.Find("GAME_MANAGER"));
		Debug.Log(currentState);
	}
}
