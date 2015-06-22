using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

	public AudioSource background;
	public AudioSource chat;

	public AudioSource stars;

	public AudioSource click;

	public AudioListener gameSounds;



	public void activateSound () {
		background.Play ();
		chat.Play ();
	}

	public void StarSound()
	{
		stars.Play();
	}

	public void ToppingButtons()
	{
		click.Play();
	}

	public void TurnOffAllSounds()
	{
		if(AudioListener.volume == 1)
		{
			AudioListener.volume = 0;
		}else
		{
			AudioListener.volume = 1;
		}
	}

	public void TurnOnAllSounds()
	{

	}
}
