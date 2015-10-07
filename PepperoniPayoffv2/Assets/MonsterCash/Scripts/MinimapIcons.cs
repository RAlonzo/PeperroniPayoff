using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinimapIcons : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        Application.LoadLevel(5);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}
