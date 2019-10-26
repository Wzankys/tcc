using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public int playerNumber;

    private int selectionIndex;
    
    //private GameObject obj;
    

    private bool haveInstance = false;

    private Object[] loadedObjects;
    private List<GameObject> charactersList;
    
    
    void Start()
    {
        loadedObjects = Resources.LoadAll("LoadScenePrefabs", typeof(GameObject));
        Debug.Log("Tamanho:"+loadedObjects.Length);
        selectionIndex = 0;
        LoadAll();
        charactersList[selectionIndex].SetActive(true);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Previous();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Next();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            selectCharacter();
        }
        
    }

    public void LoadAll()
    {
        for (int i = 0; i < loadedObjects.Length; i++)
        {
            GameObject obj = Instantiate(loadedObjects[i]) as GameObject;
            obj.transform.position = transform.position;
            obj.SetActive(false);
            charactersList.Add(obj);
            Debug.Log("Instanciando:" + obj.name);
        }
        
    }

    public void Next()
    {
        charactersList[selectionIndex].SetActive(false);
        selectionIndex++;
        charactersList[selectionIndex].SetActive(true);
        VerifyIndex(ref selectionIndex);
        haveInstance = false;
        Debug.Log("Index: "+selectionIndex);
    }

    public void Previous()
    {
        charactersList[selectionIndex].SetActive(false);
        selectionIndex--;
        charactersList[selectionIndex].SetActive(true);
        VerifyIndex(ref selectionIndex);
        Debug.Log("Index: "+selectionIndex);
    }

    public void VerifyIndex(ref int index)
    {
        if (index > charactersList.Count ) { index = 0; }
        else if(index < 0)
        {
            index = charactersList.Count ;
        }
    }
    
    private void selectCharacter()
    {
        charactersList[selectionIndex].GetComponent<Animator>().SetBool("Selected",true);
        
    }
    
}
