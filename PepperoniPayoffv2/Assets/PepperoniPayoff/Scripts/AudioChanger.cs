using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioChanger : MonoBehaviour {
	public AudioClip otherClip;

	public AudioClip[] otherClips;

	public Text songText;

	int i;

	IEnumerator Start() {
		AudioSource audio = GetComponent<AudioSource>();
		i = 0;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = otherClip;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (i);
		SetSongText();
	}

	public void SetSongText() {
		songText.text = otherClips[i].name.ToString ();
	}

	public void changeSong(int c_state) {

		AudioSource audio = GetComponent<AudioSource>();

		switch(c_state) {

		case 1:
			if(otherClips.Length > i) {
				i++;
			}

			if(i < otherClips.Length)
			{
				audio.clip = otherClips[i];
				audio.Play();
			}
			else{
				i = 0;
				audio.clip = otherClips[i];
				audio.Play();
			}
			break;

		case 0:
			if(otherClips.Length > i) {
				i--;
			}

			if(i > otherClips.Length)
			{
				audio.clip = otherClips[i];
				audio.Play();
			}
			else{
				i = otherClips.Length - 1;
				audio.clip = otherClips[i];
				audio.Play();
			}
			break;
		}
	}
}
