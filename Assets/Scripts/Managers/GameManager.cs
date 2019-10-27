using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static SelectionSettings _selectionSettings;
    public SpriteRenderer background;
    
    public static void Show(SelectionSettings settings)
    {
        SceneManager.LoadScene("Game");
        _selectionSettings = settings;
    }
    void Start()
    {
        background.sprite = _selectionSettings.selectedArena.sprite;
        foreach (var player in _selectionSettings.selectionInfos)
        {
            Instantiate(player.selectedCharacter.prefab);
        }
    }

    void Update()
    {
        
    }
}
