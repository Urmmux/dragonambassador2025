using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum GameState{
        TitleMenu,
        PauseMenu,
        PlayerMove,
        //changes via DetectLocation
        LocationInteract,
        //Territory Expansion should happen while player is interacting
        //changes via ExitLocationButton
        NPCMove,
        //changes via actionManager
        NPCResolve,
        //need to set ActionDecided properties on NPCs to false -check battleManager
        //changes via BattleManager
    }

    public GameState currentGameState = GameState.TitleMenu;
    // Start is called before the first frame update
    void Start()
    {
        //TODO, remove this line after a working title menu
        currentGameState = GameState.PlayerMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
