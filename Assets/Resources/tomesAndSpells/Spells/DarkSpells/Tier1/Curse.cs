using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : Spell
{
    public Curse(){
        spellName = "Curse";
        description = "Lay a simple curse on the target.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //applies cursed
}
