using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Get a reference to this script from the script that gets input from the user
//This way you can call the SetMaterial method.
//Alternatively, include this functionality in the script that gets the input and instantiates the prefab.

public class PrefabManager : MonoBehaviour {

	public GameObject[] pepperoni;
	public GameObject[] mushroom;
	public GameObject[] blackOlive;
	public GameObject[] jalapeno;
	public GameObject[] bacon;
	public GameObject[] greenPepper;
	public GameObject[] anchovies;
	public GameObject[] sausague;


	//int startTopping;
	
	public bool[] activeTopping;

	new Vector3 startPosition;

	float duration = 0.05f; // This will be your time in seconds.
	float smoothness = 0.005f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	
//	IEnumerator LerpPepperoniTopping() {
//		float progress = 0.2f; //This float will serve as the 3rd parameter of the lerp function.
//		float increment = smoothness/duration; //The amount of change to apply.

//	}


	//call this method with any prefab index and any material index
	public void setTopping(int index)
	{
		//Debug.Log (activeTopping);
			int i;
			switch (index) {

			case 3:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
			break;

			case 2:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						mushroom[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						mushroom[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
			break;
			
			case 1:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						bacon[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						bacon[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
			break;

			case 0:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						jalapeno[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						jalapeno[i].SetActive (false);
				}
					activeTopping[index] = false;
				}
			break;	
			}
		}
	}

