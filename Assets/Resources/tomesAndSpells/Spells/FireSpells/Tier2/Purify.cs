using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purify : Spell
{
    public Purify(){
        spellName = "Purify";
        description = "Burn incense to remove up to 3 status effects.";
        cooldown = 4;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //removes up to 3 status effects
}
