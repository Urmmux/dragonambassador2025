using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public StateManager stateManager;
    public DragonList dragonList;
    bool queueStarted = false;
    TerritoryExpand territoryExpand;
    private List<Transform> movingSprites = new List<Transform>();
     public List<OngoingBattle> battleQueue = new List<OngoingBattle>();
    // Start is called before the first frame update
    void Start()
    {
        //get our stuff!
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        dragonList = GameObject.Find("DragonManager").GetComponent<DragonList>();
        territoryExpand = GameObject.Find("void").GetComponent<TerritoryExpand>();
    }

    void Update()
    {
        //if it ain't done yet and we are in the NPC resolve phase, do it
        if (stateManager.currentGameState == StateManager.GameState.NPCResolve && !queueStarted){
            queueStarted = true;
            Invoke("DoQueue", 0.5f);
        }
    }

    public void DoQueue(){
        foreach (OngoingBattle battle in battleQueue){
            //give player a turn or more to react, countdown to things resolving without the player
            if (battle.timeToClear > 0){
                battle.timeToClear -= 1;
                continue;
            }

            if (battle.battleType == "dragon-dragon"){
                //get stats
                DragStats attackerStats = battle.attacker.GetComponent<DragStats>();
                DragStats defenderStats = battle.defender.GetComponent<DragStats>();
                //roll to randomize power a bit
                int attackerRoll = attackerStats.power + Random.Range(0, 4);
                int defenderRoll = defenderStats.power + Random.Range(0, 4);
                //assess who won
                if (attackerRoll > defenderRoll){
                    //attacker wins half money
                    int wealthExchange = Random.Range(Mathf.FloorToInt(defenderStats.wealth/2), defenderStats.wealth);
                    Debug.Log(battle.defender.name + " was killed by " + battle.attacker.name);
                    //update defender
                    defenderStats.isHome = false;
                    defenderStats.isAlive = false;
                    defenderStats.isBeingAttacked = false;
                    defenderStats.Grievance(battle.attacker, "death");
                    defenderStats.wealth -= wealthExchange;
                    defenderStats.homeRoost.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 1);
                    //remove territory from defender
                    territoryExpand.RemoveTerritory(battle.defender);
                    //update attacker
                    attackerStats.isHome = true;
                    attackerStats.grievances[battle.defender] = new List<string>();
                    attackerStats.mostRecentBigEvent = "dragonBattle_" + battle.defender.name;
                    //attacker takes individual pieces of treasure once implemented
                    attackerStats.wealth += wealthExchange;
                    attackerStats.power += Random.Range(1, 4);
                    //start moving sprite
                    Transform overworldSprite = battle.attacker.transform.GetChild(1).gameObject.transform;
                    StartCoroutine(ReturnOverworldSprite(overworldSprite, attackerStats.homeRoost.transform.position));
                }
                if (attackerRoll == defenderRoll){
                    Debug.Log(battle.defender.name + " tied in a battle with " + battle.attacker.name);
                    //update defender
                    defenderStats.Grievance(battle.attacker, "attacked");
                    defenderStats.isBeingAttacked = false;
                    //update attacker
                    attackerStats.isHome = true;
                    //move sprite
                    Transform overworldSprite = battle.attacker.transform.GetChild(1).gameObject.transform;
                    StartCoroutine(ReturnOverworldSprite(overworldSprite, attackerStats.homeRoost.transform.position));

                }
                if (attackerRoll < defenderRoll){
                    //defender gets half money
                    int wealthExchange = Random.Range(Mathf.FloorToInt(attackerStats.wealth/2), attackerStats.wealth);
                    Debug.Log(battle.defender.name + " defended herself against " + battle.attacker.name);
                    //update attacker
                    attackerStats.isAlive = false;
                    if (attackerStats.honor <= 2){
                        attackerStats.Grievance(battle.defender, "death");
                    }
                    attackerStats.wealth -= wealthExchange;
                    //remove attacker territory
                    territoryExpand.RemoveTerritory(battle.attacker);
                    //update defender
                    defenderStats.grievances[battle.attacker] = new List<string>();
                    defenderStats.mostRecentBigEvent = "dragonBattle_" + battle.attacker.name;
                    defenderStats.wealth += wealthExchange;
                    //defender takes individual pieces of treasure once implemented
                    defenderStats.power += Random.Range(1, 4);
                    defenderStats.isBeingAttacked = false;
                    //remove attacker sprite
                    battle.attacker.transform.GetChild(1).gameObject.SetActive(false);
                }
            }

            if (battle.battleType == "hero-dragon"){

            }

            if (battle.battleType == "dragon-hero"){

            }

        }

        StartCoroutine(TransitionToPlayerMove());
    }

    IEnumerator TransitionToPlayerMove(){
        while (movingSprites.Count > 0)
        {
            yield return null;
        }

        stateManager.currentGameState = StateManager.GameState.PlayerMove;
        queueStarted = false;
        //grab every NPC, add heroes and any other NPC types you add here

        foreach (GameObject dragon in dragonList.dragonList)
        {
            dragon.GetComponent<DragonBrain>().ActionDecided = false;
        }
    }

    IEnumerator ReturnOverworldSprite(Transform sprite, Vector3 destination){
        //move sprite back to roost if attacking dragon won
        float speed = 10f;
        float threshold = 0.1f;

        movingSprites.Add(sprite.transform);
        while (Vector3.Distance(sprite.position, destination) > threshold)
        {
            sprite.position = Vector3.MoveTowards(sprite.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        sprite.position = destination;
        sprite.gameObject.SetActive(false);
        DragStats stats = sprite.parent.GetComponent<DragStats>();
        stats.homeRoost.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        movingSprites.Remove(sprite.transform);
    }
}
