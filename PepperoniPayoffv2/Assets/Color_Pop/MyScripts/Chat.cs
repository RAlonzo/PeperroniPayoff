using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Chat : MonoBehaviour {


    public Text inputtedText;
    public Text moveInputtedText;
    public InputField inField;
    List<string> chattedStuff = new List<string>();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Enter()
    {
        chattedStuff.Add(inField.text);
        if (chattedStuff.Contains(inField.text))
        {
            foreach (string line in chattedStuff)
            {
                moveInputtedText.text += line;
            }
            chattedStuff.Clear();
            inField.text = "";
        }
    }
}
