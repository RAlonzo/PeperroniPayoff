using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RacerSelection : MonoBehaviour {

    public GameObject iconHolder;
    public GameObject iconEndPos;

    public Button startBttn;

    public Image[] zombieImgs;
    public Image[] zombieX;
    public Image[] holderImg;
    public Button[] zombieBttn;
    public Button[] holderBttn;

    public Image[] unusedImg;
    public Image[] unusedHolders;

    int full;

    public int[] racerHolder;
    public bool[] holders;

    //float speed = 0.5f;

    public float journeyTime = 5.0f;
    //private float startTime;

    float duration = 0.3f; // This will be your time in seconds.
    float smoothness = 0.01f;
    
    // Use this for initialization
    void Start () {
        //startTime = Time.time;
        full = 0;

        for (int i = 0; i < 3; i++)
        {
            holders[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Selection(int index)
    {
        switch(index)
        {
            case 4:
                addFull();
                HolderCheck(index);
                break;
            case 3:
                addFull();
                HolderCheck(index);
                break;
            case 2:
                addFull();
                HolderCheck(index);
                break;
            case 1:
                addFull();
                HolderCheck(index);
                break;
            case 0:
                addFull();
                HolderCheck(index);
                break;
        }
    }

    public void UnSelect(int index)
    {
        switch(index)
        {
            case 2:
                subtractFull();
                HolderClean(index);
                break;
            case 1:
                subtractFull();
                HolderClean(index);
                break;
            case 0:
                subtractFull();
                HolderClean(index);
                break;
        }
    }
    void subtractFull()
    {
        Debug.Log(full);
        if (full > 0)
            full--;

        if (full < 3)
        {
            startBttn.interactable = false;
        }
    }


    void addFull()
    {
        Debug.Log(full);
        if (full < 3)
            full++;

        if (full == 3)
        {
            startBttn.interactable = true;
        }
    }

    public void unusedCleaner()
    {
        int[] tempHolder = new int[] { -1, -1, -1, -1, -1 };
        for (int i = 0; i < 5; i++)
        {
            if (zombieX[i].gameObject.activeSelf)
            {
                zombieX[i].gameObject.SetActive(false);
                tempHolder[i] = i;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if(i != tempHolder[i])
            {
                zombieImgs[i].gameObject.SetActive(false);
            }

        }
    }

    void HolderClean(int index)
    {
        zombieX[racerHolder[index]].gameObject.SetActive(false);
        StartCoroutine(LerpIconsOut(racerHolder[index],index));
        zombieBttn[racerHolder[index]].gameObject.SetActive(true);
        holderBttn[index].gameObject.SetActive(false);
        holders[index] = false;
    }


    void HolderCheck(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (holders[i] == false)
            {
                holders[i] = true;
                racerHolder[i] = index;
                StartCoroutine(LerpIconsIn(index, i));
                zombieBttn[index].gameObject.SetActive(false);
                holderBttn[i].gameObject.SetActive(true);
                zombieX[index].gameObject.SetActive(true);
                break;
            }
        }
    }

    public void IconAnimation()
    {
        StartCoroutine(LerpIconsHolder());
    }

    IEnumerator LerpIconsHolder()
    {
        //StopAllCoroutines();
        duration = 6f;
        smoothness = 0.01f;
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.

        while (progress < 1)
        {
            iconHolder.transform.position = Vector2.Lerp(iconHolder.transform.position,
                                                                iconEndPos.transform.position,
                                                                progress);
            progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        yield return true;
    }




    IEnumerator LerpIconsIn(int index, int i)
    {
        //StopAllCoroutines();
        float duration = 0.3f;
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness/duration; //The amount of change to apply.

        while(progress < 1)
        {
        zombieImgs[index].transform.position = Vector2.Lerp(zombieX[index].transform.position,
                                                            holderImg[i].transform.position,
                                                            progress);
           progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        yield return true;
    }

    IEnumerator LerpIconsOut(int index, int i)
    {
        //StopAllCoroutines();
        float duration = 0.3f;
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.

        while (progress < 1)
        {
            zombieImgs[index].transform.position = Vector2.Lerp(holderImg[i].transform.position,
                                                                zombieX[index].transform.position,
                                                                progress);
            progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        yield return true;
    }

}

