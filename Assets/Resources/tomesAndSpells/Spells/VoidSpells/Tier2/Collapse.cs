using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : Spell
{
    public Collapse(){
        spellName = "Collapse";
        description = "Cause space to collapse in on itself, dealing damage and inflicting exhausted";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //minor void damage and inflict exhausted
}
