using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshFall : Spell
{
    public AshFall(){
        spellName = "Ash-Fall";
        description = "Hot ash pelts your enemy from above, burning them.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts burn
}
