using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Spell
{
    public Wait(){
        spellName = "Wait";
        description = "Do Nothing.";
        cooldown = 0;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {
        return;
    }
}
