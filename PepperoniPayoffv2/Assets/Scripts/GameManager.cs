using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum GAME_STATES{menu,game,end};
	GAME_STATES currentState;

	// Use this for initialization
	void Start () {
		Debug.Log(currentState);
		currentState = GAME_STATES.menu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		currentState = GAME_STATES.game;
		Debug.Log(currentState);
	}

	public void EndScreen()
	{
		currentState = GAME_STATES.end;
		Debug.Log(currentState);
	}
}
