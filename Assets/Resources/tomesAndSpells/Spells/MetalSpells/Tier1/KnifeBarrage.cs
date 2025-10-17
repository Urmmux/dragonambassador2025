using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBarrage : Spell
{
    public KnifeBarrage(){
        spellName = "Knife Barrage";
        description = "Conjure dozens of small knives and hurl them at your enemy.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //metal damage, uses the target's defense, inflicts bleed
}
