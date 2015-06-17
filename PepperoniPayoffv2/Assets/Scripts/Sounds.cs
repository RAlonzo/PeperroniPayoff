using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

	public AudioSource background;
	public AudioSource chat;

	public void activateSound () {
		background.Play ();
		chat.Play ();
	}

}
