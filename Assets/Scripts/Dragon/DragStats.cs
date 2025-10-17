using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragStats : MonoBehaviour
{
    [Header("Behavoir")]
    public string dragName;
    public int power;
    //starts 10-15
    public int wealth;

    public int playerAffection;
    //0-19 hostile to player, 20 - 29, dislikes player, 
    // 30-39 neutral to player, 40-49 starting to like player, 
    // 50-59 friendly to player, 60-69 trusts and is attached to player,
    // 70-79 familiar with player, considered in a relationship
    // cap at 79 until player cuts ties with any other dragon in a relationship and commits
    // 80-89 devoted to player
    // 90 max affection, eligable for marriage
    public string affinity;
    //elemental affinity
    public string favTreasure;
    //gains grievance against dragons with this treasure type, affection gain doubled when being gifted this treasure type
    public string favColor;
    //affection gain doubled when being gifted treasure of this color
    public int brutality;
    //more incentive to attack weaker opponents, responds well to strength, responds poorly to peaceful solutions
    //range 1-4
    public int vainity;
    //responds well to flattery
    // range 1-3
    public int jealousy;
    //gains grievance against dragons the player gives gifts to, responds poorly to talking about other dragons positively
    //range 1-3
    public int expansionist;
    //gains territory faster
    // range 1-3
    public bool collector;
    //strong goal of collecting one of each color of their favorite treasure, responds well to intelligent or nerdy dialogue
    // 1/4 change
    public bool sloth;
    //slow to set current goals, responds well to restful and peaceful dialogue
    // 1/5 chance
    public bool romantic;
    //gains affection faster, responds well to romance
    // 1/4 chance
    public bool ruler;
    //goal of owning towns and cities, cities provide more income
    // 1/5 chance
    public int social;
    //will visit other dragons and automatically remove grievances from both parties, responds well to peaceful solutions
    // range 1-3
    public bool moody;
    //more randomization on goals, responds randomly to dialogue
    // 1/5 chance
    public bool traveler;
    //will visit other dragons, as well as towns and cities, responds well to talk of distant locations
    // 1/3 chance
    public bool resurrectionist;
    //will give clues on how to bring back a dragon as undead if prompted
    // 1/3 chance
    public bool reader;
    //responds well to intelligent or nerdy dialogue, can decipher tomes for the player
    // 1/5 chance
    public int proactivity;
    //will take down heroes faster
    // range 1-3
    public int boredom;
    //will take more and more drastic actions if this goes up, will go up if not sloth and nothing happens
    // starts range 1-3
    public int confidence;
    //will take riskier fights quicker
    // starts range 1-3
    public int honor;
    //responds well to honorable dialogue, and poorly to cowardly dialogue
    // range 1-4
    public bool dreamer;
    //will tell the player random information about other dragons
    // 1/15 chance
    public bool shifter;
    //will sometimes visit cities disguised as a hero
    // 1/10 chance
    public bool intolerant;
    //will destroy any cities or towns in their territory, gains wealth from destroying them
    // 1/10 chance, and incompatable with ruler

    [Header("color")]
    public int skinColor;
    public int hornColor;
    public int eyeColor;
    public int hairColor;
    public int scaleColor;

    [Header("Home")]
    public GameObject homeRoost;

    [Header("History")]
    public Dictionary<GameObject, List<string>> grievances = new Dictionary<GameObject, List<string>>();
    //grievance types, "territory", "death" (dragon was killed by), "attacked"
    public bool isAlive = true;

    public string mostRecentBigEvent = "";
    // events should be written as "type of event_gameobject name of relevant gameobject"
    //for example "dragonBattle_dragon1"
    //should be reserved for things the dragon would need to have a conversation about

    [Header("Availability")]
    public bool isHome = true;
    public bool isBeingVisited = false;
    public bool isBeingAttacked = false;

    public bool isBeingAttackedByHero = false;

    [Header("Decisions")]
    public string currentGoal = "";
    //goals should be written as 
    //"verb_gameobject name(name of cell if a location sprite)_type of thing(dragon, knight, city, etc...)"
    //for example "attack_dragon1_dragon"
    public List<string> goalList;

    [Header("Battle")]

    public List<Spell> abilities;
    // all battle stats are set at the start of a battle
    //set health to 20 + power*2
    //set resistance to 5 + 1/2 power + vainity
    //set defense to 5 + 1/2 power + 4 if sloth
    //set tempPower to power, use tempPower for all move calculations
    //set will to 10 -brutality -jealousy +expansionist +4 if sloth +Random.Range(-5, 4) if moody, +4 if ruler, -boredom*2, +honor
    //set status effects to empy list at the start of fight
    IEnumerator Start(){
        //make sure everything else initialized first
        yield return 0;
        //set up the grievance lists
        List<GameObject> dragonList = GameObject.Find("DragonManager").GetComponent<DragonList>().dragonList;
        foreach (GameObject dragon in dragonList){
            grievances.Add(dragon, new List<string>());
        }
    }

    public void Grievance(GameObject dragon, string grievanceType)
    {
        grievances[dragon].Add(grievanceType);
        foreach (var g in grievances[dragon]){
            
        }
    }

    public bool IsAvailable(){
        //can this dragon be a target for other dragons?
        return isHome && !isBeingAttacked && !isBeingVisited && !isBeingAttackedByHero;
    }


}
