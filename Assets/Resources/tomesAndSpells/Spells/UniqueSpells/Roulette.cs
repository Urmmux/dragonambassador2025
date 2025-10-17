using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : Spell
{
    public Roulette(){
        spellName = "Roulette";
        description = "Has a random effect.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //add entropy to roll, roll 1-15
    //1-5 take dark damage
    //5-7 gain sealed
    //9-10 gain regeneration
    //11 deal massive frost damage
    //12-14 target gains protected and vulnerable
    //15 inflict bleed, overloaded, and burn
    //16 lose all entropy and deal damage based on amount of entropy
}
