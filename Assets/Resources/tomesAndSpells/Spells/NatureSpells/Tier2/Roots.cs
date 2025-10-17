using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : Spell
{
    public Roots(){
        spellName = "Roots";
        description = "Gain regeneration by sinking roots into the earth and absorbing nutrients.";
        cooldown = 3;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //gain regeration for 3 turns, magnitude is greater if wet
}
