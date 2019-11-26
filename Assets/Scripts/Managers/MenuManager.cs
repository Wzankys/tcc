using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private string start, cancel;

    public GameObject audioManager;

    //private AudioSource audioSource;
    public AudioClip transitionSound;
    
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
            StartCoroutine(LoadSceneCoroutine());
        }

        if (Input.GetButton(cancel))
        {
            Application.Quit();
        }

    }

    IEnumerator LoadSceneCoroutine()
    {
       AudioManager.Instance.Play(transitionSound,false);
        yield return new WaitWhile(()=>AudioManager.Instance.isPlaying());
        SceneManager.LoadScene("Select");
    }
}