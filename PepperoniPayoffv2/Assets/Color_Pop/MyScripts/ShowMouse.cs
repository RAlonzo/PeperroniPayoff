using UnityEngine;
using System.Collections;

public class ShowMouse : MonoBehaviour {

	public MouseScript mouseScript;

	void OnMouseOver(){
		mouseScript.showCursor = true;
	}
	void OnMouseExit(){
		mouseScript.showCursor = false;
	}

}
