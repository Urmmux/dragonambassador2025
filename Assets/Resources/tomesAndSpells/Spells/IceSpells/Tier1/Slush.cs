using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slush : Spell
{
    public Slush(){
        spellName = "Slush";
        description = "A wave of half-frozen water drenches your target.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts wet
}
