using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : Spell
{
    public Focus(){
        spellName = "Focus";
        description = "Only affects yourself, and focuses your physical power.";
        cooldown = 0;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //only affects caster, raise power
}
