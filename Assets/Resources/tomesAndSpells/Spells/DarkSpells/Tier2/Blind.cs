using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : Spell
{
    public Blind(){
        spellName = "Blind";
        description = "Blind your enemy, with no chance to resist.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts blind, ignores resistance
}
