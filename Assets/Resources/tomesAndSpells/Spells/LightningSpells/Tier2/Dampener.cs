using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dampener : Spell
{
    public Dampener(){
        spellName = "Dampener";
        description = "Temporarily negates all electric damage from a target.";
        cooldown = 5;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //apply blackout for 4 turns, 2 turns against dragons
}
