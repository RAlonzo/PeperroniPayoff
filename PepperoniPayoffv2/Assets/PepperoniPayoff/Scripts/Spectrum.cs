using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spectrum : MonoBehaviour {

	public GameObject prefab;
	public GameObject prefab2;
	public GameObject prefab3;

	public Rigidbody plane;
	public Rigidbody plane2;
	public Rigidbody plane3;
	public Rigidbody planeClone;
	public Rigidbody planeClone2;
	public Rigidbody planeClone3;

	public int numberOfObjects; 
	public int numberOfObjects2;
	public int numberOfObjects3;

	public float radius;
	public float radius2;
	public float radius3;
	public float speed;
	public float temp;
	public float PlaneDelay;
	public float PlaneDelay2;
	public float PlaneDelay3;
	public float timer;
	public float timer2;
	public float timer3;

	public Text minblueText;
	public Text maxblueText;
	public Text minyellowText;
	public Text maxyellowText;
	public Text minredText;
	public Text maxredText;

	public float minBlue;
	public float maxBlue;
	public float minYellow;
	public float maxYellow;
	public float minRed;
	public float maxRed;

	public GameObject[] cubes;
	public GameObject[] cubes2;
	public GameObject[] cubes3;

	public Vector3 previousScale;
	public Vector3 previousPos;
	public Vector3 previousScale2;
	public Vector3 previousPos2;
	public Vector3 previousScale3;
	public Vector3 previousPos3;

	void Start() {
		numberOfObjects = 40;
		numberOfObjects2 = 20;
		numberOfObjects3 = 20;
		radius = 6.0f;
     	radius2 = 5.0f;
		radius3 = 4.0f;
     	speed = 10f;
    	temp = 0.0f;
     	PlaneDelay  = 0.0f;
		PlaneDelay2  = 0.0f;
		PlaneDelay3  = 0.0f;
		timer = 0.0f;
		timer2 = 0.0f;
		timer3 = 0.0f;

		minBlue = 0.8f;
		SetBlueText(0);

     	maxBlue = 0.9f;
		SetBlueText(1);

		minYellow = 1.3f;
		SetYellowText(0);

     	maxYellow = 1.4f;
		SetYellowText(1);

		minRed = 1.5f;
		SetRedText(0);

    	maxRed = 1.70f;
		SetRedText(1);

		cubes = new GameObject[numberOfObjects];
     	cubes2 = new GameObject[numberOfObjects2];
		cubes3 = new GameObject[numberOfObjects3];

		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
			Instantiate(prefab, pos, Quaternion.identity);
		}
		cubes = GameObject.FindGameObjectsWithTag("cubes");

		for (int j = 0; j < numberOfObjects2; j++) {
			float angle = j * Mathf.PI * 2 / numberOfObjects2;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius2;
			Instantiate(prefab2, pos, Quaternion.identity);
		}
		cubes2 = GameObject.FindGameObjectsWithTag("cubes2");

		for (int k = 0; k < numberOfObjects3; k++) {
			float angle = k * Mathf.PI * 2 / numberOfObjects3;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius3;
			Instantiate(prefab3, pos, Quaternion.identity);
		}
		cubes3 = GameObject.FindGameObjectsWithTag("cubes3");
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.Rotate(0,0,20*Time.deltaTime);

		timer += Time.deltaTime;
		float [] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);
		
		for(int i = 0; i < numberOfObjects; i++){

			previousScale = cubes[i].transform.localScale;
			previousPos = cubes[i].transform.localPosition;

			previousPos.y = Mathf.Lerp (previousPos.y, spectrum[i] * 52, Time.deltaTime * 30);
			previousScale.y = Mathf.Lerp (previousScale.y, spectrum[i] * 104, Time.deltaTime * 30);
			cubes[i].transform.localPosition = previousPos;
			cubes[i].transform.localScale = previousScale;

			if(previousScale.y>temp){
				temp=previousScale.y;
			}

			if(previousScale.y >= minBlue && previousScale.y <= maxBlue && timer >= PlaneDelay) {
				timer = 0.0f;
				if(cubes[i].transform.position.x > 0 && cubes[i].transform.position.z > 0){
					planeClone = (Rigidbody) Instantiate(plane2, cubes[i].transform.position, Quaternion.Euler(0,45, 0));
				}else if(cubes[i].transform.position.x < 0 && cubes[i].transform.position.z > 0){
					planeClone = (Rigidbody) Instantiate(plane2, cubes[i].transform.position, Quaternion.Euler(0,-45, 0));
				}else if(cubes[i].transform.position.x < 0 && cubes[i].transform.position.z < 0){
					planeClone = (Rigidbody) Instantiate(plane2, cubes[i].transform.position, Quaternion.Euler(0,45, 0));
				}else if (cubes[i].transform.position.x > 0 && cubes[i].transform.position.z < 0) {
					planeClone = (Rigidbody) Instantiate(plane2, cubes[i].transform.position, Quaternion.Euler(0,-45, 0));
				}

			planeClone.velocity = transform.forward * -speed;
			}


		}

		for (int k = 0; k < numberOfObjects2; k++) {
			previousScale3 = cubes3 [k].transform.localScale;
			previousPos3 = cubes3 [k].transform.localPosition;
			previousPos3.y = Mathf.Lerp (previousPos3.y, spectrum [k] * 13, Time.deltaTime * 30);
			previousScale3.y = Mathf.Lerp (previousScale3.y, spectrum [k] * 26, Time.deltaTime * 30);
			cubes3[k].transform.localPosition = previousPos3;
			cubes3[k].transform.localScale = previousScale3;

			if (previousScale3.y >= minYellow && previousScale3.y <= maxYellow && timer >= PlaneDelay2) {
				timer2 = 0.0f;

				if(cubes3[k].transform.position.x > 0 && cubes3[k].transform.position.z > 0){
					planeClone2 = (Rigidbody)Instantiate (plane, cubes3[k].transform.localPosition, Quaternion.Euler (0, 45, 0));
				}else if(cubes3[k].transform.position.x < 0 && cubes[k].transform.position.z > 0){
					planeClone2 = (Rigidbody)Instantiate (plane, cubes3[k].transform.localPosition, Quaternion.Euler (0, -45, 0));
				}else if(cubes3[k].transform.position.x < 0 && cubes3[k].transform.position.z < 0){
					planeClone2 = (Rigidbody)Instantiate (plane, cubes3[k].transform.localPosition, Quaternion.Euler (0, 45, 0));
				}else if (cubes3[k].transform.position.x > 0 && cubes3[k].transform.position.z < 0) {
					planeClone2 = (Rigidbody)Instantiate (plane, cubes3[k].transform.localPosition, Quaternion.Euler (0, -45, 0));
				}

			planeClone2.velocity = transform.forward * -speed;
			}
		}



		Debug.Log ("Max Number");
		Debug.Log (temp);

		for(int j = 0; j < numberOfObjects2; j++){
			previousScale2 = cubes2[j].transform.localScale;
			previousPos2 = cubes2[j].transform.localPosition;
			previousPos2.y = Mathf.Lerp (previousPos2.y, spectrum[j] * 13, Time.deltaTime * 30);
			previousScale2.y = Mathf.Lerp (previousScale2.y, spectrum[j] * 26, Time.deltaTime * 30);
			cubes2[j].transform.localPosition = previousPos2;
			cubes2[j].transform.localScale = previousScale2;

			if(previousScale2.y >= minRed && previousScale2.y <= maxRed && timer >= PlaneDelay3) {
				timer3 = 0.0f;

				if(cubes2[j].transform.position.x > 0 && cubes2[j].transform.position.z > 0){
					planeClone3 = (Rigidbody)Instantiate (plane3, cubes2[j].transform.localPosition, Quaternion.Euler (0, 45, 0));
				}else if(cubes2[j].transform.position.x < 0 && cubes2[j].transform.position.z > 0){
					planeClone3 = (Rigidbody)Instantiate (plane3, cubes2[j].transform.localPosition, Quaternion.Euler (0, -45, 0));
				}else if(cubes2[j].transform.position.x < 0 && cubes2[j].transform.position.z < 0){
					planeClone3 = (Rigidbody)Instantiate (plane3, cubes2[j].transform.localPosition, Quaternion.Euler (0, 45, 0));
				}else if (cubes2[j].transform.position.x > 0 && cubes2[j].transform.position.z < 0) {
					planeClone3 = (Rigidbody)Instantiate (plane3, cubes2[j].transform.localPosition, Quaternion.Euler (0, -45, 0));
				}

			planeClone3.velocity = transform.forward * -speed;
			}
		}
	}
	public void SetMinBlueVar(int index) {
		switch (index) {
			
		case 1:
			minBlue = minBlue + 0.1f;
			SetBlueText(0);
			break;
			
		case 0:
			minBlue = minBlue - 0.1f;
			SetBlueText(0);
			break;
		}
	}

	public void SetMaxBlueVar(int index) {
		switch (index) {
			
		case 1:
			maxBlue = maxBlue + 0.1f;
			SetBlueText(1);
			break;
			
		case 0:
			maxBlue = maxBlue - 0.1f;
			SetBlueText(1);
			break;
		}
	}

	public void SetMinYellowVar(int index) {
		switch (index) {
			
		case 1:
			minYellow = minYellow + 0.1f;
			SetYellowText(0);
			break;
			
		case 0:
			minYellow = minYellow - 0.1f;
			SetYellowText(0);
			break;
		}
	}
	
	public void SetMaxYellowVar(int index) {
		switch (index) {
			
		case 1:
			maxYellow = maxYellow + 0.1f;
			SetYellowText(1);
			break;
			
		case 0:
			maxYellow = maxYellow - 0.1f;
			SetYellowText(1);
			break;
		}
	}

	public void SetMinRedVar(int index) {
		switch (index) {
			
		case 1:
			minRed = minRed + 0.1f;
			SetRedText(0);
			break;
			
		case 0:
			minRed = minRed - 0.1f;
			SetRedText(0);
			break;
		}
	}
	
	public void SetMaxRedVar(int index) {
		switch (index) {
			
		case 1:
			maxRed = maxRed + 0.1f;
			SetRedText(1);
			break;
			
		case 0:
			maxRed = maxRed - 0.1f;
			SetRedText(1);
			break;
		}
	}

	public void SetBlueText(int index) {
		switch (index) {
			
		case 1:
			maxblueText.text = maxBlue.ToString ();
			break;
			
		case 0:
			minblueText.text = minBlue.ToString ();
			break;
		}
	}

	public void SetYellowText(int index) {
		switch (index) {
			
		case 1:
			maxyellowText.text = maxYellow.ToString ();
			break;
			
		case 0:
			minyellowText.text = minYellow.ToString ();
			break;
		}
	}

	public void SetRedText(int index) {
		switch (index) {

		case 1:
			maxredText.text = maxRed.ToString ();
			break;

		case 0:
			minredText.text = minRed.ToString ();
			break;
		}
	}
}
