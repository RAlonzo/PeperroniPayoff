using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ChefControllerScript : MonoBehaviour {

	private Animator chefAnimator;

	int currentState;

	// Use this for initialization
	void Start () {
		currentState = 1;
		chefAnimator = GetComponent<Animator>();
		chefAnimator.SetBool("Passing", true);
	}
	
	// Update is called once per frame
	void Update () {
		int randomState = Random.Range(0,3);

		if(currentState != randomState){
			chefAnimator.SetInteger("IdleState", randomState);
			currentState = randomState;
		}
		else{
			randomState = Random.Range(0,3);
		}
	}
}
