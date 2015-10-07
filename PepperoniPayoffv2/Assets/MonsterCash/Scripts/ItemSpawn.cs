using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {

    public Rigidbody2D frostPrefab;
    public Rigidbody2D shovelPrefab;
    public Rigidbody2D webPrefab;

    public GameObject[] racers;

    public float temPosition;
    public float highPsoition;

    // Use this for initialization
    void Start () {
        highPsoition = racers[1].transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < 5; i++)
        {
            temPosition = racers[i].transform.position.x;
            for(int j = 0; j < 5; j++)
            {
                if(temPosition > highPsoition)
                {
                    highPsoition = racers[j].transform.position.x;
                }
            }
        }
	}

    public void ItemInstanciate(int index)
    {
        switch (index)
        {
            case 3:
                WebItem();
                break;
            case 2:
                ShovelItem();
                break;
            case 1:
                FrostItem();
                break;
        }
    }

    void FrostItem()
    {
        Rigidbody2D frostClone = (Rigidbody2D)Instantiate(frostPrefab, new Vector3(highPsoition + 20, Random.Range(0, 5), 0),Quaternion.identity);
    }

    void ShovelItem()
    {
        Rigidbody2D shovelClone = (Rigidbody2D)Instantiate(shovelPrefab, new Vector3(highPsoition + 20, Random.Range(0, 5), 0), Quaternion.identity);
    }

    void WebItem()
    {
        Rigidbody2D webClone = (Rigidbody2D)Instantiate(webPrefab, new Vector3(highPsoition + 20, Random.Range(0, 5), 0), Quaternion.identity);
    }




}
