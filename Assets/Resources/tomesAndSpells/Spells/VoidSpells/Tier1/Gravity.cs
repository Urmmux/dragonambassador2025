using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Spell
{
    public Gravity(){
        spellName = "Gravity";
        description = "Inflicts heavy on the target, dealing void damage over time.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts heavy on target
}
