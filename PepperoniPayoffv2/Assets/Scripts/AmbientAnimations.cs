using UnityEngine;
using System.Collections;

public class AmbientAnimations : MonoBehaviour {

	public Animation Register;
	public AnimationClip pop;

    public AudioClip registerSound;

    private AudioSource source;

	// Use this for initialization
	void Awake () {
        source = GetComponent<AudioSource>();
		Register.AddClip(pop,"pop");
		Register.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
        source.PlayOneShot(registerSound);
		Register.Play("pop");
	}
}
