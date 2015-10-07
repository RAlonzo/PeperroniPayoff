using UnityEngine;
using System.Collections;

public class RandomColors : MonoBehaviour {


    private int randomColor;
	// Use this for initialization
    void Awake()
    {
        randomColor = Random.Range(0, 7);
    }
	void Start () {
        switch(randomColor)
        {
            case 0:
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 4:
                GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case 5:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 6:
                GetComponent<Renderer>().material.color = Color.gray;
                break;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
