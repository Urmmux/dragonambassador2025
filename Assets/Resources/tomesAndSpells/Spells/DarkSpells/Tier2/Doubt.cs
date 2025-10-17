using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubt : Spell
{
    public Doubt(){
        spellName = "Doubt";
        description = "ummon a manifestation of doubt that deals dark damage. The more the target doubts, the more damage they take.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //deals dark damage, based on targets will instead of resistance
}
