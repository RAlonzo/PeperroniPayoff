using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public AudioSource sliceSource;

	public int startTopping;
	public int currentTopping;


    public List<GameObject> thrownObjects = new List<GameObject>();


	//int startTopping;
	
	public bool[] activeTopping;

	new Vector3 startPosition;

	float duration = 0.05f; // This will be your time in seconds.
	float smoothness = 0.005f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	
//	IEnumerator LerpPepperoniTopping() {
//		float progress = 0.2f; //This float will serve as the 3rd parameter of the lerp function.
//		float increment = smoothness/duration; //The amount of change to apply.

	void Start()
	{
		startTopping = 0;
		setTopping (startTopping);
	}



    IEnumerator WaitTime(int index)
    {
        sliceSource.PlayDelayed(1.7f);
        yield return new WaitForSeconds(2.7f);
        foreach(GameObject topping in thrownObjects)
        {
            topping.SetActive(false);
        }
        setTopping(index);
        yield return 0;
    }


    public void StartWaitTimer(int index)
    {
        StartCoroutine(WaitTime(index));
    }



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
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){
                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (true);
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}
			break;

			case 2:
				if(!activeTopping[index]){
                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (true);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){

                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (true);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}
			break;
			
			case 1:
				if(!activeTopping[index]){

                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (true);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){

                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (false);
						bacon[i].SetActive (true);
					}
					activeTopping[index] = true;
				}
			break;

			case 0:
				if(!activeTopping[index]){

                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (true);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}else if(activeTopping[index]){

                    for (i = 0; i < 9; i++) {
						pepperoni[i].SetActive (false);
						mushroom[i].SetActive (false);
						jalapeno[i].SetActive (true);
						bacon[i].SetActive (false);
					}
					activeTopping[index] = true;
				}
			break;	
			}
		}
	}

