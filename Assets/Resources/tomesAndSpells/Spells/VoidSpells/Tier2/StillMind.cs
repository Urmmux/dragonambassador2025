using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillMind : Spell
{
    public override void Cast(GameObject caster, GameObject target) {}

    public StillMind(){
        spellName = "Still Mind";
        description = "Increases the will of the target";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }
    //Increases will of the target
}
