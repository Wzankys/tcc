using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : Singleton<HudManager> {
    public List<CharacterSelection> players;
    public ArenaSelection arena;
    private int remainingPlayers = 2;
    private bool[] everythingSelected;

    private SelectionSettings settings = new SelectionSettings ();

    // Start is called before the first frame update
    void Start () {
        //ForEach using lambda C#
        players.ForEach ((player) => player.enabled = true);
        arena.enabled = false;
    }

    public void OnPlayerSelected (int playerNumber, GameObject prefab) {
        
        SelectionInfo selected = new SelectionInfo ();
        selected.selectedCharacter.prefab = prefab;
        selected.selectedCharacter.number = playerNumber;
        settings.selectionInfos.Add (selected);
        remainingPlayers--;
        Debug.Log("Remaining PLayers: " + remainingPlayers);
        Debug.Log("Inseri:" + playerNumber);
			
        if(remainingPlayers <= 0) {
            players.ForEach ((player) => player.enabled = false);
            arena.enabled = true;
        }
    }

    public void OnSelectedArena (Sprite selection) {
        settings.selectedArena.sprite = selection;
        Debug.Log("Tamanho do array sendo passado pra proxima cena: " + settings.selectionInfos.Count);
        GameManager.Show (settings);
    }

}