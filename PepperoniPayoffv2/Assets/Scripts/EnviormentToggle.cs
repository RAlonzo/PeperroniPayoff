using UnityEngine;
using System.Collections;

public class EnviormentToggle : MonoBehaviour {

	public GameObject[] enviorment;

	// Update is called once per frame
	public void activateEnviorment(int index) {
		enviorment[index].SetActive(true);
	}
}
