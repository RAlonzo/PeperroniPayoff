using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoaderScript : MonoBehaviour {

	public int levelToLoad;


	public GameObject backgorund;
	public GameObject text;
	public GameObject progressBar;


	private int loadProgress;

	void Start()
	{
		//backgorund.SetActive(false);
		//text.SetActive(false);
		//progressBar.SetActive(false);
		loadProgress = 0; //at the begining we want to be sure that the progress is set to 0 for a more accurate loading estimate.
		StartCoroutine(DisplayLoadingScreen(levelToLoad)); //Start loading whatever level you want.
		
	}

	void Update()
	{

	}

	IEnumerator DisplayLoadingScreen(int level)
	{
		backgorund.SetActive(true); // turn on everything
		text.SetActive(true);
		progressBar.SetActive(true);

		//below will set it to 0, because the load progress at the begining is 0. This will make the bar's scale 0 in the X axis
		progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

		//progressBar.transform.localScale = Vector3.Lerp(new Vector3(progressBar.transform.localScale.x, progressBar.transform.localScale.y, progressBar.transform.localScale.z),new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z), Time.deltaTime);

		text.GetComponent<GUIText>().text = "Loading Progress: " + loadProgress + "%";

		//This loads another scene in the background of a current scene
		AsyncOperation async = Application.LoadLevelAsync(level);
		
		while ( !async.isDone)
		{
			loadProgress = (int)(async.progress * 100); //Async shows a number from 0 - 1.  We want 0 to 100, so we multiply by 100.
			text.GetComponent<GUIText>().text = "Loading..."; // Show Preparing pizzas above bar
			//transform the scale of the bar in the x to the size of the async progress (0 - 1).  At 1, the bar is full sized, and next level will be loaded
			progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
			//progressBar.transform.localPosition = new Vector3(async.progress, progressBar.transform.localPosition.y, progressBar.transform.localPosition.z);
			yield return null; // break out -- then come back if its not done
		}
	}


} 
