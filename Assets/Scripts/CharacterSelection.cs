using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public int playerNumber;

    private int selectionIndex;

    private Object[] characterList;
    
    void Start()
    {
        characterList = Resources.LoadAll("Prefabs", typeof(GameObject));
        Debug.Log("Tamanho:"+characterList.Length);
        selectionIndex = 0;
    }
    
    void Update()
    {

        for (int i = 0; i < 1; i++)
        {
            _Instantiate();
        }
        
        void OnKeyPressed()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Next();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Previous();
            }
        }
    }

    public void _Instantiate()
    {
        GameObject obj = Instantiate(characterList[selectionIndex]) as GameObject;
        obj.transform.position = transform.position;
        Debug.Log("Instanciando:" + obj.name);
    }

    public void Next()
    {
        selectionIndex++;
        VerifyIndex(ref selectionIndex);
        Debug.Log("Index: "+selectionIndex);
    }

    public void Previous()
    {
        selectionIndex--;
        VerifyIndex(ref selectionIndex);
        Debug.Log("Index: "+selectionIndex);
    }

    public void VerifyIndex(ref int index)
    {
        if (index > characterList.Length - 1) { index = 0; }
        else if(index < 0)
        {
            index = characterList.Length - 1;
        }
    }

    private void selectCharacter()
    {
        
    }
    
}
