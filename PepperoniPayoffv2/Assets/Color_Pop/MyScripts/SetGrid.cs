using UnityEngine;
using System.Collections;

public class SetGrid : MonoBehaviour {

	public GameObject balloons;


	public GameObject NumberPlaceHolder;

	public Transform refrenceBallon;
	public int Width = 10;
	public int Height = 10;
	public int Xspacing = 4;
	public int Yspacing = 4;
	//public int blockWidth; 
	private GameObject [,] grid = new GameObject[10,10];
    public AudioSource audioSource;
    public NumberManager numManager;
    public TicketManager tixMan;

    void Awake () 
	{
		/*for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				GameObject gridPiece = (GameObject)Instantiate(balloons);
				//gridPiece.transform.position = new Vector3(gridPiece.transform.position.x +x*spacing,
				   //                                        gridPiece.transform.position.y +y*spacing, 40);
				gridPiece.transform.position = new Vector3(refrenceBallon.transform.position.x +x*Xspacing,
				                                           refrenceBallon.transform.position.y +y*Yspacing, 40);
				grid[x,y] = gridPiece;
			}
		}
        */

	}


    public void InitGrid()
    {
        StartCoroutine(CoolStart());
    }

    IEnumerator CoolStart()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                yield return new WaitForSeconds(.003f);
                audioSource.Play();
                GameObject gridPiece = (GameObject)Instantiate(balloons);
                //gridPiece.transform.position = new Vector3(gridPiece.transform.position.x +x*spacing,
                //                                        gridPiece.transform.position.y +y*spacing, 40);
                gridPiece.transform.position = new Vector3(refrenceBallon.transform.position.x + x * Xspacing,
                                                           refrenceBallon.transform.position.y + y * Yspacing, 40);
                gridPiece.transform.localScale = new Vector3(Random.Range(.65f, .9f), Random.Range(.65f, .9f), Random.Range(.65f, .9f));
                grid[x, y] = gridPiece;
            }
        }
        yield return 0;
    }


    public void BuildGrid()
    {
        if (numManager.OutOfTix)
        {
            tixMan.OutOfTicketsLOSE();
        }
        else
        {
            StartCoroutine(DestroyAllBalloons());
        }
       
    }

    public void ReplayGrid()
    {
        numManager.ticketNumber = 1;
        numManager.TicOneTxt.text = "";
        StartCoroutine(ReplayDestroyAllBalloons());
    }

    IEnumerator ReplayDestroyAllBalloons()
    {
        GameObject[] balloonsNew;
        GameObject[] nums;
        balloonsNew = GameObject.FindGameObjectsWithTag("Balloon");
        nums = GameObject.FindGameObjectsWithTag("Number");
        //yield return new WaitForSeconds(2);
        foreach (GameObject balloon in balloonsNew)
        {
            Destroy(balloon);
        }
        yield return new WaitForSeconds(.3f);
        foreach (GameObject num in nums)
        {
            Destroy(num);
        }
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                yield return new WaitForSeconds(.003f);
                audioSource.Play();
                GameObject gridPiece = (GameObject)Instantiate(balloons);
                //gridPiece.transform.position = new Vector3(gridPiece.transform.position.x +x*spacing,
                //                                        gridPiece.transform.position.y +y*spacing, 40);
                gridPiece.transform.position = new Vector3(refrenceBallon.transform.position.x + x * Xspacing,
                                                           refrenceBallon.transform.position.y + y * Yspacing, 40);
                gridPiece.transform.localScale = new Vector3(Random.Range(.65f, .9f), Random.Range(.65f, .9f), Random.Range(.65f, .9f));

                grid[x, y] = gridPiece;
            }
        }
        numManager.OutOfDarts = false;


        yield return 0;
    }
    IEnumerator DestroyAllBalloons()
    {
        GameObject[] balloonsNew;
        GameObject[] nums;
        balloonsNew = GameObject.FindGameObjectsWithTag("Balloon");
        nums = GameObject.FindGameObjectsWithTag("Number");
        yield return new WaitForSeconds(2);
        foreach (GameObject balloon in balloonsNew)
        {
            Destroy(balloon);
        }
        yield return new WaitForSeconds(.3f);
        foreach(GameObject num in nums)
        {
            Destroy(num);
        }
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                yield return new WaitForSeconds(.003f);
                audioSource.Play();
                GameObject gridPiece = (GameObject)Instantiate(balloons);
                //gridPiece.transform.position = new Vector3(gridPiece.transform.position.x +x*spacing,
                //                                        gridPiece.transform.position.y +y*spacing, 40);
                gridPiece.transform.position = new Vector3(refrenceBallon.transform.position.x + x * Xspacing,
                                                           refrenceBallon.transform.position.y + y * Yspacing, 40);
                gridPiece.transform.localScale = new Vector3(Random.Range(.65f, .9f), Random.Range(.65f, .9f), Random.Range(.65f, .9f));

                grid[x, y] = gridPiece;
            }
        }
        numManager.OutOfDarts = false;


        yield return 0;
    }


}
