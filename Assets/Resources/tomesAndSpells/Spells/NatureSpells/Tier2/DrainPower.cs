using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainPower : Spell
{
    public DrainPower(){
        spellName = "Drain Power";
        description = "Steal power from your enemy and use it to increase your will.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //reduces tempPower and increases caster's will
}
