using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour {

    public bool startBonusGame;
    public GameObject leftSideCanvas;
    public GameObject timerandnumbers;

    public GameObject chestone;
    public GameObject chesttwo;
    public GameObject chestthree;

    public Transform placementOne;
    public Transform placementTwo;
    public Transform placementThree;

    public GameObject Bonus2D;


    private float smoothness = 0.02f;
    private float duration = 1.0f;

    public GameObject bonusCanvas;

    public List<GameObject> objectsToToggle = new List<GameObject>();


	// Use this for initialization
	void Start () {
        startBonusGame = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(startBonusGame)
        {
            bonusCanvas.SetActive(true);
            Bonus2D.SetActive(true);
            foreach(GameObject obj in objectsToToggle)
            {
                obj.SetActive(false);
            }
            StartCoroutine(MoveObject(chestone, placementOne));
            leftSideCanvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            timerandnumbers.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            //leftSideCanvas.SetActive(false);
            //timerandnumbers.SetActive(false);
        }
        else
        {
            foreach(GameObject obj in objectsToToggle)
            {
                obj.SetActive(true);
            }
            leftSideCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            timerandnumbers.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            bonusCanvas.SetActive(false);
            Bonus2D.SetActive(false);
        }
	}

    IEnumerator MoveObject(GameObject objFrom, Transform objTo)
    {
        float progress = 0;
        float increment = smoothness / duration;
        yield return new WaitForSeconds(.4f);
        while (progress < 1)
        {
            objFrom.transform.position = Vector3.Lerp(objFrom.transform.position, objTo.transform.position, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }


        yield return 0;
    }
}
