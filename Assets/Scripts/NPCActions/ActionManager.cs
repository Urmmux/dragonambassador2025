using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public StateManager stateManager;
    public BattleManager battleManager;
    bool queueStarted = false;

    private List<Transform> movingSprites = new List<Transform>();
    public List<ActionRequest> actionQueue = new List<ActionRequest>();
    void Start()
    {
        //get managers
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        battleManager = gameObject.GetComponent<BattleManager>();
    }

    // Update is called once per frame
    public void Update(){
        //if the queue hasn't been done yet and it's NPC move, start the queue
        if (stateManager.currentGameState == StateManager.GameState.NPCMove && !queueStarted){
            queueStarted = true;
            Invoke("DoQueue", 0.2f);
        }
    }

    public void RequestAction(ActionRequest request){
        actionQueue.Add(request);
    }

    public void DoQueue(){
        //start doing actions
        while (actionQueue.Count > 0){
            //get an action at random
            int randomIndex = Random.Range(0, actionQueue.Count);
            ActionRequest request = actionQueue[randomIndex];

            //add here for each new target type
            //add here one layer deep for each new actor type
            //add here two layers deep for each new action type

            if (request.targetType == "dragon"){
                DragStats targetStats = request.targetController.GetComponent<DragStats>();
                if (targetStats.IsAvailable()){

                    if (request.actor.name.Contains("dragon")){
                        //dragon performing action with dragon
                        DragStats actorStats = request.actor.GetComponent<DragStats>();
                        if (actorStats.IsAvailable()){

                            if (request.actionType == "attack"){
                                //actor and target are not available, grey out the roost of the attacker
                                actorStats.isHome = false;
                                actorStats.homeRoost.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 1);
                                targetStats.isBeingAttacked = true;
                                //move the sprite to the target
                                GameObject overworldSprite = request.actor.transform.GetChild(1).gameObject;
                                overworldSprite.SetActive(true);
                                overworldSprite.transform.position = actorStats.homeRoost.transform.position;
                                StartCoroutine(MoveOverworldSprite(overworldSprite.transform, request.moveTargetSprite.transform.position));
                                //send battle to the battlemanager
                                battleManager.battleQueue.Add(new OngoingBattle("dragon-dragon", request.actor, request.targetController));
                            }
                        }
                    }
                }
            }

            actionQueue.RemoveAt(randomIndex);
        }
        StartCoroutine(WaitForAllMovements());
    }

    IEnumerator MoveOverworldSprite(Transform sprite, Vector3 destination){
        float speed = 10f;
        float threshold = 0.1f;
        //add moving sprite to list so that we can wait on them to move
        movingSprites.Add(sprite.transform);
        while (Vector3.Distance(sprite.position, destination) > threshold)
        {
            sprite.position = Vector3.MoveTowards(sprite.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        sprite.position = destination;
        //sprite has finished moving
        movingSprites.Remove(sprite.transform);
    }

    IEnumerator WaitForAllMovements()
    {
        while (movingSprites.Count > 0)
        {
            yield return null;
        }
    // All sprites are done moving — safe to continue
    stateManager.currentGameState = StateManager.GameState.NPCResolve;
    queueStarted = false;
    }  
}
