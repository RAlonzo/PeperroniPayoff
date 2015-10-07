using UnityEngine;
using System.Collections;

public class RacerMovement : MonoBehaviour {

    public GameObject finishLine;
    public GameObject startLine;
    float acceleration;
    bool raceStart;

    public AudioClip revSound;

    private AudioSource source;

    private float volLowRange = 0.1f;
    private float volHighRange = 0.2f;

    // Use this for initialization
    void Awake () {
        source = GetComponent<AudioSource>();
        raceStart = false;
        acceleration = Random.Range(0.01f, 0.03f);
        Debug.Log(acceleration);
    }
	
	// Update is called once per frame
	void Update () {
        if(raceStart == true)
        {
            Vector3 position = this.transform.position;
            if (position.x >= 25 && position.x <= 25.2f)
            {
                Deccelerate();
                Debug.Log(acceleration);
            }
            else if (position.x >= 50 && position.x <= 50.2f)
            {
                Accelerate();
                Debug.Log(acceleration);
            }
            else if (position.x >= 75 && position.x <= 75.2f)
            {
                Deccelerate();
                Debug.Log(acceleration);
            }
            position.x = position.x + acceleration + 0.06f;
            this.transform.position = position;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Frost")
        {
            Debug.Log("Frost");
            Destroy(coll.gameObject);
            Deccelerate();
        }

        if (coll.gameObject.tag == "Shovel")
        {
            Debug.Log("Shovel");
            Destroy(coll.gameObject);
            Deccelerate();
        }

        if (coll.gameObject.tag == "Web")
        {
            Debug.Log("Web");
            Destroy(coll.gameObject);
            Deccelerate();
        }
    }

    void Deccelerate()
    {
        acceleration = Random.Range(-0.03f, -0.01f);
    }

    void Accelerate()
    {
        acceleration = Random.Range(0.00f, 0.025f);
    }

    IEnumerator RaceStart()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        yield return new WaitForSeconds(3);
        source.PlayOneShot(revSound, vol);
        raceStart = true;
    }

    public void startRace()
    {
        StartCoroutine(RaceStart());
    }
}
