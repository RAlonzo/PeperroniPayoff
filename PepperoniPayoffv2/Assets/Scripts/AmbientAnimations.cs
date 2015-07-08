using UnityEngine;
using System.Collections;

public class AmbientAnimations : MonoBehaviour {

	public Animation Register;
	public AnimationClip pop;

	// Use this for initialization
	void Start () {
		Register.AddClip(pop,"pop");
		Register.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Register.Play("pop");
	}
}
