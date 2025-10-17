using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLocationButton : MonoBehaviour
{
    StateManager stateManager;
    LSController lSController;
    // Start is called before the first frame update
    void Start()
    {
        lSController = GameObject.Find("LocationScreen").GetComponent<LSController>();
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void ExitLocation()
    {
        lSController.CloseLocation();
        stateManager.currentGameState = StateManager.GameState.NPCMove;
        // stateManager.currentGameState = StateManager.GameState.PlayerMove;
        // comment above for testing;
    }
}
