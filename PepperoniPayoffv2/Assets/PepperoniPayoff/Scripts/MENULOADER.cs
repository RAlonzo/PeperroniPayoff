using UnityEngine;
using System.Collections;

public class MENULOADER : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PP()
    {
        Application.LoadLevel(2);
    }

    public void CP()
    {
        Application.LoadLevel(6);
    }

    public void MC()
    {
        Application.LoadLevel(5);
    }
}
