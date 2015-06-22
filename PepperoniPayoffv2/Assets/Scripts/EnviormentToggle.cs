using UnityEngine;
using System.Collections;

public class EnviormentToggle : MonoBehaviour {

	public GameObject[] enviorment;

	int startEnviorment;
	int currentEnviorment;
	bool firstTime;

	// Use this for initialization
	void Start () {
		firstTime = true;
		startEnviorment = Random.Range (0, 2);
		Debug.Log (startEnviorment);
		currentEnviorment = startEnviorment;
		changeEnviorment (startEnviorment);
	}
	
	// Update is called once per frame
	public void changeEnviorment(int index) {
		if (currentEnviorment != index || firstTime) {
			firstTime = false;
			enviorment[currentEnviorment].SetActive(false);
			enviorment[index].SetActive (true);
			currentEnviorment = index;
		}
	}
}
