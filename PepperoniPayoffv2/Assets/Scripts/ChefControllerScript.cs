using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ChefControllerScript : MonoBehaviour {

	private Animator chefAnimator;
	private HashIDs hash;

	private bool idleState;
	private bool danceState;
	private bool sliceState;
	private bool poseState;

	int i_currentState;
	int d_currentState;
	int randomState;

	void Awake(){

		i_currentState = 1;
		d_currentState =0;
		chefAnimator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

		chefAnimator.SetLayerWeight(1, 1f);
		chefAnimator.SetLayerWeight(2, 1f);
		chefAnimator.SetLayerWeight(3, 1f);

		idleState = true;
		danceState = false;
		sliceState = false;
		chefAnimator.SetBool (hash.idlestateBool, true);

		StartCoroutine(ChefState());
	}

	// Update is called once per frame
	IEnumerator ChefState () {
		while(idleState = true)
		{
			Idle();
			yield return new WaitForSeconds(3);
		}
		while (danceState = true)
		{
			yield return new WaitForSeconds(2);
			idleState =  true;
		}
		while (sliceState =  true)
		{
			yield return new WaitForSeconds(2);
			idleState =  true;
		}
		while (poseState =  true)
		{
			yield return new WaitForSeconds(2);
			idleState =  true;
		}
	}

	void Idle(){
		Debug.Log("Idle");
		RandomState();
		chefAnimator.SetBool (hash.sliceBool, false);
		chefAnimator.SetBool (hash.danceBool, false);
		chefAnimator.SetBool (hash.idlestateBool, true);

		if(i_currentState != randomState){
			chefAnimator.SetInteger(hash.idleInteger, randomState);
			i_currentState = randomState;
		}
		else{
			RandomState();
		}
	}

	public void Slice()
	{
		Debug.Log("Slice");
		idleState =  false;
		chefAnimator.SetBool (hash.idlestateBool, false);
		chefAnimator.SetBool (hash.sliceBool, true);
	}

	public void Pose()
	{
		Debug.Log("Pose");
		idleState =  false;
		chefAnimator.SetBool (hash.idlestateBool, false);
		chefAnimator.SetBool (hash.poseBool, true);
	}

	public void Dance()
	{
		Debug.Log("Dancing");
		RandomState();
		idleState =  false;
		chefAnimator.SetBool (hash.idlestateBool, false);
		//chefAnimator.SetBool ("Passing", true);
		chefAnimator.SetBool (hash.danceBool, true);

		if(d_currentState != randomState){
			chefAnimator.SetInteger (hash.dancemoveInteger, randomState);
			d_currentState = randomState;
			//chefAnimator.SetBool ("Idle", true);
		}
		else{
			RandomState();
		}
	}

	void RandomState()
	{
		randomState = Random.Range(0,3);
	}
}
