using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private string start, cancel;
    // Start is called before the first frame update
    void Start()
    {
        start = "Start";
        cancel = "Cancel";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(start))
        {
            SceneManager.LoadScene("Select");
        }

        if (Input.GetButton(cancel))
        {
            Application.Quit();
        }

    }
}