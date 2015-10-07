#pragma strict

var barInnerCover : RectTransform;

function Start () {
	// Show a custom loading bar if this is the web version; otherwise just go to the title screen level
	if (Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer) {
		LoadingProgressBar();
	}
	else {
		Application.LoadLevel (2);
	}
}

function LoadingProgressBar () {
	// Reveal loading bar as the level is streamed, by reducing the size delta x of the loading bar cover (which is anchored on the right)
	// Note that the outer bar is 9-sliced using the sprite editor, so it can be scaled to any size without distorting the edges
	var startSizeDelta = barInnerCover.sizeDelta;
	while (!Application.CanStreamedLevelBeLoaded (2)) {
		var loadPercent = Application.GetStreamProgressForLevel (2);
		barInnerCover.sizeDelta.x = Mathf.Lerp (startSizeDelta.x, 0.0, loadPercent);
		yield;
	}
	
	Application.LoadLevel (2);
}