using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : Spell
{
    public override void Cast(GameObject caster, GameObject target) {}

    public Reflection(){
        spellName = "Reflection";
        description = "Copies all status effects from a target";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }
    //copies all status effects from the target
}
