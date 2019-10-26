using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public int playerNumber;

    private int selectionIndex;
    
    //private GameObject obj;

    private bool haveInstance = false;

    private Object[] characterList;
    
    void Start()
    {
        characterList = Resources.LoadAll("LoadingData", typeof(GameObject));
        Debug.Log("Tamanho:"+characterList.Length);
        selectionIndex = 0;
        _Instantiate();
    }
    
    void Update()
    {

        if(!haveInstance)
            _Instantiate();
        
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Previous();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Next();
        }
        
    }

    public void _Instantiate()
    {
        GameObject obj = Instantiate(characterList[selectionIndex]) as GameObject;
        obj.transform.position = transform.position;
        Debug.Log("Instanciando:" + obj.name);
        haveInstance = true;
    }

    public void Next()
    {
        selectionIndex++;
        VerifyIndex(ref selectionIndex);
        haveInstance = false;
        Debug.Log("Index: "+selectionIndex);
    }

    public void Previous()
    {
        selectionIndex--;
        VerifyIndex(ref selectionIndex);
        haveInstance = false;
        Debug.Log("Index: "+selectionIndex);
    }

    public void VerifyIndex(ref int index)
    {
        if (index > characterList.Length ) { index = 0; }
        else if(index < 0)
        {
            index = characterList.Length ;
        }
    }

    private void selectCharacter()
    {
        
    }
    
}
