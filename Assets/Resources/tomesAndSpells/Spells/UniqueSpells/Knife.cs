using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Spell
{
    public Knife(){
        spellName = "Knife";
        description = "Stab.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {
        DamageTarget(1, caster, target, true, true);
    }
}
