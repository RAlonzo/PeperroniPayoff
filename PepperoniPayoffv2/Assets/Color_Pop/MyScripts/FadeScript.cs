using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<Renderer>().enabled)
		{
			StartCoroutine(StartFade());
		}
	}
	
	IEnumerator StartFade()
	{
		yield return new WaitForSeconds(1);
		this.gameObject.GetComponent<Renderer>().enabled = false;
		yield return 0;
	}


}
