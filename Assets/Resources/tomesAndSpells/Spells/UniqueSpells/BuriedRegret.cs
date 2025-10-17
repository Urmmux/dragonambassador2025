using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriedRegret : Spell
{
    public BuriedRegret(){
        spellName = "Buried Regret";
        description = "Brings back a memory of a terrible mistake.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //base - give "bitterness" status effect to caster
    //if has caster has status "comfort", override and apply sealed to target
    //if has caster has status "desire", override and deal a large amount of a random damage type to target
}
