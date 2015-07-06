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
		loadProgress = 0;
		StartCoroutine(DisplayLoadingScreen(levelToLoad));
		
	}

	void Update()
	{

	}

	IEnumerator DisplayLoadingScreen(int level)
	{
		backgorund.SetActive(true);
		text.SetActive(true);
		progressBar.SetActive(true);

		progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

		//progressBar.transform.localScale = Vector3.Lerp(new Vector3(progressBar.transform.localScale.x, progressBar.transform.localScale.y, progressBar.transform.localScale.z),new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z), Time.deltaTime);

		text.GetComponent<GUIText>().text = "Loading Progress: " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync(level);
		
		while ( !async.isDone)
		{
			loadProgress = (int)(async.progress * 100);
			text.GetComponent<GUIText>().text = "Preparing Pizzas...";
			progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
			//progressBar.transform.localPosition = new Vector3(async.progress, progressBar.transform.localPosition.y, progressBar.transform.localPosition.z);
			yield return null;
		}
	}


} 
