using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {


    public Animation OpenAnim;
    public AnimationClip OpenClip;

	// Use this for initialization
	void Start () {
        OpenAnim.AddClip(OpenClip, "Open");
        OpenAnim.Stop("Open");
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnMouseDown()
    {
        OpenAnim.Play();
    }
}
