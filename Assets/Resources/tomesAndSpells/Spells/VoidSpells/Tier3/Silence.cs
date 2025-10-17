using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silence : Spell
{
    public override void Cast(GameObject caster, GameObject target) {

        StartCooldown();
    }

    public Silence(){
        spellName = "Silence";
        description = "Permanantly silence your enemies.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
    //inflicts silence
}
