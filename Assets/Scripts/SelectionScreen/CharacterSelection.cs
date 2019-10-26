using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public int playerNumber;

    private int selectionIndex;

    private float selectionDelay;

    public float delayTime;
    
    //inputs
    private string leftButton;
    private string rightButton;
    private string selectionButton;

    private bool haveInstance = false;
    
    private Animator animator;

    private List<AnimatorOverrideController> charactersList = new List<AnimatorOverrideController>();

    private bool alreadySelected;
    
    void Start()
    { 
        leftButton = "Left"+playerNumber;
        rightButton = "Right"+playerNumber;
        selectionButton = "Selection"+playerNumber;
        var controllers = Resources.LoadAll("LoadingObjects", typeof(AnimatorOverrideController));
        Debug.Log("Tamanho:"+controllers.Length);
        selectionIndex = 0;
        LoadAll(controllers);
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = charactersList[selectionIndex];
    }
    
    void Update()
    {
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
            charactersList.Add(loadedObjects[i] as AnimatorOverrideController);
        }
        
    }

    public void Next()
    {
        selectionIndex++;
        VerifyIndex(ref selectionIndex);
        animator.runtimeAnimatorController = charactersList[selectionIndex];
        haveInstance = false;
        Debug.Log("Index: "+selectionIndex);
    }

    public void Previous()
    {
        selectionIndex--;
        VerifyIndex(ref selectionIndex);
        animator.runtimeAnimatorController = charactersList[selectionIndex];
        Debug.Log("Index: "+selectionIndex);
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
        HudManager.Instance.OnPlayerSelected(playerNumber,charactersList[selectionIndex].name);
    }
    
}
