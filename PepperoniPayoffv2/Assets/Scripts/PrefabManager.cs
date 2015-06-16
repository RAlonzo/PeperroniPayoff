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
	
	int startTopping;
	
	public bool[] activeTopping;

	//// Use this for initialization
	void Start () {
		for (int i = 0; i < 7; i++) {
			activeTopping[i] = false;
		}
		startTopping = Random.Range (0, 6);
		setTopping (startTopping);
	}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
	
	//call this method with any prefab index and any material index
	public void setTopping(int index)
	{
		Debug.Log (activeTopping);
			int i;
			switch (index) {

			case 6:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						anchovies[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						anchovies[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
				break;
			
			case 5:
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

			case 4:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						greenPepper[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						greenPepper[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
				break;
			
			case 3:
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
			
			case 2:
				if(!activeTopping[index]){
					for (i = 0; i < 9; i++) {
						blackOlive[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
					for (i = 0; i < 9; i++) {
						blackOlive[i].SetActive (false);
					}
					activeTopping[index] = false;
				}
			break;
			
			case 1:
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

			case 0:
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
			}
		}
	}

