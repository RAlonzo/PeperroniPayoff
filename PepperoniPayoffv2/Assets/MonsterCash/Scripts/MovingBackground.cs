using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject[] zombie;

    public bool raceStart;


    // Use this for initialization
    void Start () {
        raceStart = false;
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 5; i++)
        {
            if (zombie[i].transform.position.x > 1 && this.transform.position.x < 87.0f && raceStart != false)
            {
                Vector3 position = this.transform.position;
                position.x = position.x + 0.01f;
                this.transform.position = position;
            }
        }
    }
	  
    public void RaceStart()
    {
        raceStart = true;
    }  
}
