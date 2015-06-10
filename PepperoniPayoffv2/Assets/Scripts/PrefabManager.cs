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

	public enum Toppings : int{
		pepperoni,
		mushroom,
		blackOlive,
		jalapeno,
		bacon,
		greenPepper,
		anchovies,
		supreme,
		cheese
	};

	int startTopping;
	int currentTopping;

	bool firstTime;
	//// Use this for initialization
	void Start () {
		firstTime = true;
		startTopping = Random.Range (0, 8);
		currentTopping = startTopping;
		setTopping (startTopping);
	}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
	
	//call this method with any prefab index and any material index
	public void setTopping(int index)
	{
		if (currentTopping != index || firstTime) {
			int i;
			firstTime = false;
			switch (index) {

			case 8:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					pepperoni [i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
				}
				currentTopping = index;
				break;
			
			case 7:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (true);
					blackOlive [i].SetActive (true);
					jalapeno[i].SetActive (true);
					pepperoni [i].SetActive (true);
					bacon[i].SetActive (true);
					greenPepper[i].SetActive (true);
					anchovies[i].SetActive (true);
				}
				currentTopping = index;
				break;
			
			//case Toppings.sausage:
			//	for (i = 0; i < 9; i++) {
			//		mushroom [i].SetActive (false);
			//		blackOlive [i].SetActive (false);
			//		jalapeno[i].SetActive (false);
			//		pepperoni [i].SetActive (false);
			//		bacon[i].SetActive (false);
			//		greenPepper[i].SetActive (false);
			//		anchovies[i].SetActive (true);
			//	}
			//	currentTopping = index;
			//	break;
			//}

			case 6:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					pepperoni [i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (true);
				}
				currentTopping = index;
				break;
			
			case 5:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					anchovies[i].SetActive (false);
					pepperoni [i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (true);
				}
				currentTopping = index;
				break;

			case 4:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
					pepperoni [i].SetActive (false);
					bacon[i].SetActive (true);
				}
				currentTopping = index;
				break;

			case 3:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					pepperoni [i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (true);
				}
				currentTopping = index;
				break;
			
			case 2:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					pepperoni [i].SetActive (false);
					jalapeno[i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
					blackOlive [i].SetActive (true);
				}
				currentTopping = index;
				break;

			case 1:
				for (i = 0; i < 9; i++) {
					pepperoni [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
					mushroom [i].SetActive (true);
				}
				currentTopping = index;
				break;

			case 0:
				for (i = 0; i < 9; i++) {
					mushroom [i].SetActive (false);
					blackOlive [i].SetActive (false);
					jalapeno[i].SetActive (false);
					bacon[i].SetActive (false);
					greenPepper[i].SetActive (false);
					anchovies[i].SetActive (false);
					pepperoni [i].SetActive (true);
				}
				currentTopping = index;
				break;
			}
		}
	}
}

