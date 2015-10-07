using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradientOn : MonoBehaviour
{
    private float duration = 1f;
    private float smoothness = 0.02f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        //GetComponent<Image>().CrossFadeColor(Color.clear, 1.0f, false, true);
        StartCoroutine(LerpColor());
    }

   IEnumerator LerpColor()
    {
        float progress = 0;
        float increment = smoothness / duration;

        while (progress < 1)
        {
            GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        yield return true;
    }

}