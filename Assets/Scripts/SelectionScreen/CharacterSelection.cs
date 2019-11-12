using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    public int playerNumber;
    public Image splashArt;
    private string Name;
    private Text textBox;

    private int selectionIndex;

    private float selectionDelay;

    public float delayTime;
    
    //inputs
    private string leftButton;
    private string rightButton;
    private string selectionButton;

    private bool haveInstance = false;
    
    private Animator animator;

    private AudioSource audioSource;

    private List<CharacterInfo> charactersList = new List<CharacterInfo>();

    private bool alreadySelected;
    
    void Start()
    { 
        leftButton = "Left"+playerNumber;
        rightButton = "Right"+playerNumber;
        selectionButton = "Selection"+playerNumber;
        textBox = GetComponentInChildren<Text>();
        var controllers = Resources.LoadAll("Characters", typeof(CharacterInfo));
        //Debug.Log("Tamanho:"+controllers.Length);
        selectionIndex = 0;
        LoadAll(controllers);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.runtimeAnimatorController = charactersList[selectionIndex].loadingAnimationController;
        splashArt.sprite = charactersList[selectionIndex].splashArt;
    }
    
    void Update()
    {
        textBox.text = charactersList[selectionIndex].name.ToUpper();
        splashArt.sprite = charactersList[selectionIndex].splashArt;
        //Debug.Log(charactersList[selectionIndex].name);
        if (selectionDelay < Time.time)
        {
            if (Input.GetButton(leftButton))
            {
                selectionDelay = Time.time + delayTime;
                Previous();
            }

            if (Input.GetButton(rightButton))
            {
                selectionDelay = Time.time + delayTime;
                Next();
            }
        }

        if (Input.GetButton(selectionButton))
        {
            selectCharacter();
        }
        
    }

    public void LoadAll(object[] loadedObjects)
    {
        for (int i = 0; i < loadedObjects.Length; i++)
        {
            charactersList.Add(loadedObjects[i] as CharacterInfo);
        }
        
    }

    public void Next()
    {
        selectionIndex++;
        VerifyIndex(ref selectionIndex);
        animator.runtimeAnimatorController = charactersList[selectionIndex].loadingAnimationController;
        haveInstance = false;
        //Debug.Log("Index: "+selectionIndex);
    }

    public void Previous()
    {
        selectionIndex--;
        VerifyIndex(ref selectionIndex);
        animator.runtimeAnimatorController = charactersList[selectionIndex].loadingAnimationController;
        //Debug.Log("Index: "+selectionIndex);
    }

    public void VerifyIndex(ref int index)
    {
        if (index >= charactersList.Count ) { index = 0; }
        else if(index < 0)
        {
            index = charactersList.Count - 1;
        }
    }
    
    
    private void selectCharacter()
    {
        if(alreadySelected)
            return;

        alreadySelected = true;
        animator.SetBool("Selected",true);
        audioSource.clip = charactersList[selectionIndex].prefab.GetComponent<AudioList>().sSelect;
        audioSource.Play();
        HudManager.Instance.OnPlayerSelected(playerNumber,charactersList[selectionIndex].prefab);
    }
    
}
