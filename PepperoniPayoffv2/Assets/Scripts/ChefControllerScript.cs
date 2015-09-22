using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ChefControllerScript : MonoBehaviour {

	private Animator chefAnimator;
	private HashIDs hash;

    public enum State
    {
        Idle,
        Actions
    }

    public enum Actions
    {
        Slice,
        Dance,
        Pose
    }

    private State _state; // Local variable that represents our states.

    public Actions _actions;

    int actionState;

	int i_currentState;
	int d_currentState;
	int randomState;

	void Start(){
		i_currentState = 1;
		d_currentState =0;

		chefAnimator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

		chefAnimator.SetLayerWeight(1, 1f);
		chefAnimator.SetLayerWeight(2, 1f);
		chefAnimator.SetLayerWeight(3, 1f);

        _state = State.Idle;

        StartCoroutine("ChefState");
    }

     //Update is called once per frame
     IEnumerator ChefState () {

        while (true)
        {
            switch (_state)
            {
                case State.Idle:
                    Idle();
                    break;
                case State.Actions:
                    InAction(actionState);
                    break;
            }

            yield return 0;
        }
		
    }

    public void setIndex(int index)
    {
        _state = State.Actions;
        actionState = index;
    }

    public void InAction(int index)
    {
        switch (index)
        {
            case 2:
                Pose();
                break;
            case 1:
                Slice();
                break;
            case 0:
                Dance();
                break;
        }
    }



    private void Idle(){
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

	private void Slice()
	{
		Debug.Log("Slice");
		//idleState =  false;
		chefAnimator.SetBool (hash.idlestateBool, false);
		chefAnimator.SetBool (hash.sliceBool, true);
        _state = State.Idle;
	}

	private void Pose()
	{
		Debug.Log("Pose");
		chefAnimator.SetBool (hash.idlestateBool, false);
		chefAnimator.SetBool (hash.poseBool, true);
        _state = State.Idle;
    }

	private void Dance()
	{
		Debug.Log("Dancing");
		RandomState();
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
        _state = State.Idle;
    }

	void RandomState()
	{
		randomState = Random.Range(0,3);
	}
}
