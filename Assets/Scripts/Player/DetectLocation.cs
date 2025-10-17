using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLocation : MonoBehaviour
{

    public StateManager stateManager;

    bool cantrigger = true;
    private int layermask;
    // Start is called before the first frame update
    void Start()
    {
        layermask = LayerMask.GetMask("Tiles");
    }

    // Update is called once per frame
    void Update()
    {
        //get stats of current cell
        Collider2D hit = Physics2D.OverlapPoint((Vector2)transform.position, layermask);
        CellStats stats = hit.gameObject.GetComponent<CellStats>();
        //if cell has an overworld structure, and state is playermove, and has moved off a location they were standing on previously
        bool hasOverwoldStructure = stats && stats.has != CellStats.OverworldStructure.None;
        bool playerIsMoving = stateManager.currentGameState == StateManager.GameState.PlayerMove;
        if(cantrigger && hasOverwoldStructure && playerIsMoving){
            //go to location interact and open that location
            stateManager.currentGameState = StateManager.GameState.LocationInteract;
            LSController lSController = GameObject.Find("LocationScreen").GetComponent<LSController>();
            lSController.OpenLocation(stats);
            cantrigger = false;
        } else if (!cantrigger && playerIsMoving && !hasOverwoldStructure){
            //reset if player has moved off of location they were standing on
            cantrigger = true;
        }
    }
}
