using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DragonBrain : MonoBehaviour
{
    DragStats stats;
    GameObject dragonOverworldSprite;
    public StateManager stateManager;
    public ActionManager actionManager;
    public DragonList dragonList;
    public GameObject moveTarget;
    public static event Action<ButtonInfo[]> RequestButtons;
    public static event Action<ButtonInfo[]> RequestButtonsExit;

    public bool ActionDecided = false;

    // Start is called before the first frame update
    void Start()
    {
        //get managers
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        actionManager = GameObject.Find("ActionManager").GetComponent<ActionManager>();
        dragonList = GameObject.Find("DragonManager").GetComponent<DragonList>();

        stats = gameObject.GetComponent<DragStats>();
        dragonOverworldSprite = Instantiate(Resources.Load<GameObject>("DragonOverworld"), gameObject.transform);
        Color scaleColor = new Color(1, 1, 1, 1);
        switch (stats.scaleColor)
        {
            case 1:
                scaleColor = new Color(0.5471698f, 0.1626024f, 0.1626024f, 1);
                break;
            case 2:
                scaleColor = new Color(0.6886792f, 0.1331879f, 0.4085717f, 1);
                break;
            case 3:
                scaleColor = new Color(0.383485f, 0.09033462f, 0.5471698f, 1);
                break;
            case 4:
                scaleColor = new Color(0.0249199f, 0.07691608f, 0.1509434f, 1);
                break;
            case 5:
                scaleColor = new Color(0.5257192f, 0.8018868f, 0.4728106f, 1);
                break;
            case 6:
                scaleColor = new Color(1f, 0.9507052f, 0.25f, 1);
                break;
        }
        dragonOverworldSprite.GetComponent<SpriteRenderer>().color = scaleColor;
        dragonOverworldSprite.SetActive(false);
    }

    // Dialogue and battle
    public void RunDialog(GameObject lairscreen, string dialogueChoice = null){
        Text text = lairscreen.transform.GetChild(1).GetComponent<Text>();
        //immediate concerns
        if (stats.isBeingAttacked) {
            RunAttackedDialog(lairscreen, text);
            return;
        }
        if (!stats.isHome) {
            text.text = "You wander into the lair, but the passages are sealed. The dragon isn't home.";
            return;
        }

        //no specific events or conditions
        text.text = TextLibrary.GetUneventfulGreeting(stats);
        ButtonInfo[] options = new ButtonInfo[3];
        options[0] = new ButtonInfo
        {
            label = $"Trade with {stats.dragName}",
            onClick = () => RunDialogTrade()
        };
        options[1] = new ButtonInfo
        {
            label = $"Negotiate with {stats.dragName}",
            onClick = () => RunDialogNegotiate()
        };
        options[2] = new ButtonInfo
        {
            label = $"Converse with {stats.dragName}",
            onClick = () => RunDialogConverse()
        };

        RequestButtonsExit.Invoke(options);
    }

    public void RunDialogTrade(){

    }

    public void RunDialogNegotiate(){
        
    }

    public void RunDialogConverse(){
        
    }

    public void RunAttackedDialog(GameObject lairscreen, Text text) {
        //get ongoing battle, and playerfight script
        OngoingBattle battle = GameObject.Find("ActionManager").GetComponent<BattleManager>().battleQueue.Find(x => x.defender == this.gameObject);
        PlayerFight playerFight = GameObject.Find("Player").GetComponent<PlayerFight>();
        //get stats
        DragStats attackerStats = battle.attacker.GetComponent<DragStats>();
        DragStats defenderStats = battle.defender.GetComponent<DragStats>();
        //pick text and assign it
        string randomTextPick = TextLibrary.GetStartBattleText(attackerStats, defenderStats);
        text.text = randomTextPick;
        //create button info and send it to buttonarray via event    
        ButtonInfo[] options = new ButtonInfo[3];
        options[0] = new ButtonInfo
        {
            label = $"Side with {attackerStats.dragName}",
            onClick = () => playerFight.DragonBattle(lairscreen, battle.defender, battle.attacker)
        };
        options[1] = new ButtonInfo
        {
            label = $"Side with {defenderStats.dragName}",
            onClick = () => playerFight.DragonBattle(lairscreen, battle.attacker, battle.defender)
        };
        options[2] = new ButtonInfo
        {
            label = $"Negotiate with {attackerStats.dragName}",
            onClick = () => battle.attacker.GetComponent<DragonBrain>().NegotiateWithAttacker(lairscreen, battle.defender)
        };

        RequestButtons.Invoke(options);
        return;
    }

    public void NegotiateWithAttacker(GameObject lairscreen, GameObject defender){
        Debug.Log("negotiating!");
        //switch which dragon is displayed
        defender.transform.GetChild(0).gameObject.SetActive(false);
        //some sort of transition?
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        //dialogue with attacker
    }

    //Actions and goals
    public void Update(){
        //if no action decided yet during NPCMove phase, decide an action
        if (stateManager.currentGameState == StateManager.GameState.NPCMove && !ActionDecided){
            DecideAction();
        }
    }

    public void DecideAction()
    {
        //check stats to update possible goals
        //pick random goal is temporary during development
        PickRandomDragonGoal();
        //check if currentgoal should change
        IsCurrentGoal();

        PickAction();
        ActionDecided = true; 
    }

    public void PickRandomDragonGoal(){
        //if no current goal, pick a random dragon and add a goal to attack it
        if (stats.currentGoal == ""){
        GameObject dragonTarget = dragonList.dragonList[UnityEngine.Random.Range (0, dragonList.dragonList.Count)];
        if(this.gameObject == dragonTarget){
        //back out of the function if the random target was herself
            return;
        }
        stats.goalList.Add("attack_" + dragonTarget.name + "_dragon");
        }
    }

    public void IsCurrentGoal(){
        //if there is no current goal, and the goal list is above zero, assign a goal from the goal list
        if (stats.currentGoal == ""){
            if (stats.goalList.Count > 0){
            stats.currentGoal = stats.goalList[UnityEngine.Random.Range (0, stats.goalList.Count)];
            }
        }
    }

    public void PickAction(){
        if(stats.currentGoal == ""){
            //if no goal, take no action
            return;
        }
        //parse goal into three strings
        string[] parts = stats.currentGoal.Split('_');
        string actionType = parts[0];
        string typeOfTarget = parts[2];
        //get the gameobject corresponding to the target, as well as the cell for the move target
        GameObject targetController = null;
        if (typeOfTarget == "dragon"){
        targetController = GameObject.Find(parts[1]);
        moveTarget = targetController.GetComponent<DragStats>().homeRoost;
        }
        //send request for action to the action manager
        ActionRequest request = new ActionRequest(actionType, moveTarget, targetController, typeOfTarget, this.gameObject);
        actionManager.RequestAction(request);
    }
}
