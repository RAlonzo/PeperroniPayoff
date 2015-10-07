using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIRandomNums : MonoBehaviour {

    public Text firstAItxt;
    public Text secAItxt;
    public Text thirdAItxt;
    public Text fourthAItxt;
    // Use this for initialization
    void Start () {
        firstAItxt.text = Random.Range(1, 40).ToString() +" " + Random.Range(1, 40).ToString() + " " +Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString();
        secAItxt.text = Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString();
        thirdAItxt.text = Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString();
        fourthAItxt.text = Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString() + " " + Random.Range(1, 40).ToString();
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
