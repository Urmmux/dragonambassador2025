using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OngoingBattle
{
    //battle is stored here, retrieved when player gets to lair and dragon is being attacked, lair calls dragonbrain.rundialog, calls runattackeddialogue, if player participates, calls player.playerfight.dragonbattle
    public string battleType;
    //formatted as "attacker-defender", such as "hero-dragon" or "dragon-dragon"
    //types to account for
    // "dragon-dragon"
    // "hero-dragon"
    // "dragon-hero"

    public GameObject attacker;
    public GameObject defender;
    public GameObject location;
    public int timeToClear = 1;

    // Start is called before the first frame update
    public OngoingBattle(
        string battleType,
        GameObject attacker,
        GameObject defender
    ){
        this.battleType = battleType;
        this.attacker = attacker;
        this.defender = defender;
    }
}
