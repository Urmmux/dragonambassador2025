using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public StateManager stateManager;

    public float zoomedInSize = 50;
    public float zoomedOutSize = 90;
    public float zoomSpeed = 2f;

    private Camera cam;
    private float targetSize;

    StateManager.GameState lastKnownState;
    bool needsZoomed;

    void Start()
    {
        //get our things
        cam = GetComponent<Camera>();
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        targetSize = zoomedInSize;
    }

    void Update()
    {
        //during the specific gamestate transitions, we need to zoom
        StateManager.GameState currentGameState = stateManager.currentGameState;
        if (lastKnownState != currentGameState && (currentGameState == StateManager.GameState.PlayerMove || currentGameState == StateManager.GameState.NPCMove)){
            needsZoomed = true;
            lastKnownState = currentGameState;
        }

        if (needsZoomed){
            //zoom in during player move
            if (currentGameState == StateManager.GameState.PlayerMove){
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedInSize, Time.deltaTime * zoomSpeed);
                if (Mathf.Abs(cam.fieldOfView - zoomedInSize) < 0.1f){
                    needsZoomed = false;
                }
            }
            if (currentGameState == StateManager.GameState.NPCMove){
                //zoom out during npc move
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedOutSize, Time.deltaTime * zoomSpeed);
                if (Mathf.Abs(cam.fieldOfView - zoomedInSize) < 0.1f){
                    needsZoomed = false;
                }
            }
        }
    }
}
