using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Occlusion : MonoBehaviour {

    public List<GameObject> CulledObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CullObjects(float sec)
    {
        StartCoroutine(WaitAndCull(sec));
    }


    IEnumerator WaitAndCull(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject cullableObj in CulledObjects)
        {
            cullableObj.SetActive(false);
        }
        yield return 0;
    }
}
