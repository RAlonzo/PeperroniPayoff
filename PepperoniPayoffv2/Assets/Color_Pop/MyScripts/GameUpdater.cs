using UnityEngine;
using System.Collections;

public class GameUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void NewGame()
    {
        Application.LoadLevel(6);
    }
}
