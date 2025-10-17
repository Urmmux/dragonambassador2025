using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepingShadow : Spell
{
    public CreepingShadow(){
        spellName = "Creeping Shadow";
        description = "Shadows materialize and claw at your enemy.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //deals dark damage
}
