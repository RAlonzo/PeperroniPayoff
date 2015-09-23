using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public int passingBool;
	public int passingState;
	public int threepassState;
	public int idleState;
	public int idlestateBool;
	public int idleInteger;
	public int fchopState;
	public int tgrabState;
	public int schatState;
	public int danceBool;
	public int dancemoveInteger;
	public int danceState;
	public int moonwalkState;
	public int yoyoState;
	public int raiseroofState;
	public int sliceBool;
	public int tossupState;
	public int spinchopState;
	public int poseBool;
	public int poseState;

	void Awake()
	{
		passingBool = Animator.StringToHash("Passing");
		threepassState = Animator.StringToHash("Base Layer, 3 passes");
		passingState = Animator.StringToHash("Base Layer, Passing");
		idleState = Animator.StringToHash("Base Layer, Idle");
		idlestateBool = Animator.StringToHash("Idle");
		idleInteger = Animator.StringToHash("IdleState");
		fchopState = Animator.StringToHash("Base Layer, Furious Chops");
		tgrabState = Animator.StringToHash("Base Layer, Topping Grab");
		schatState = Animator.StringToHash("Base Layer, Small Chat");
		danceBool = Animator.StringToHash("Dance");
		dancemoveInteger = Animator.StringToHash("Dancemove");
		danceState = Animator.StringToHash("Base Layer, Dance");
		moonwalkState = Animator.StringToHash("Base Layer, Moon Walk");
		yoyoState = Animator.StringToHash("Base Layer, Yoyo");
		raiseroofState = Animator.StringToHash("Base Layer, Raise Roof");
		sliceBool = Animator.StringToHash("Slice");
		tossupState = Animator.StringToHash("Base Layer, Toss Up");
		spinchopState = Animator.StringToHash("Base Layer, Spin Chop");
		poseBool = Animator.StringToHash("Pose");
		poseState = Animator.StringToHash("Base Layer, Pose");
	}
}
