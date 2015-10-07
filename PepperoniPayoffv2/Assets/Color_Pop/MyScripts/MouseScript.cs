using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
	

	public Camera mainCamera;

	public GameObject dart;

	public Texture2D cursorImage;

	private Vector2 cursorHotSpot;

	public bool showCursor = false;
	// Use this for initialization
	void Start () {
		Cursor.visible = showCursor;
		//cursorImage.Resize (200, 200);
		//cursorHotSpot = new Vector2 (cursorImage.width / 2, cursorImage.height / 2);
		//Cursor.SetCursor (cursorImage, cursorHotSpot, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		//Set the position of the target to the mouss position!
		this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);


	 }
	public void HideMouse()
	{
		showCursor = false;
	}

}
