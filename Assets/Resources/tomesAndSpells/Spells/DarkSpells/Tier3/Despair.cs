using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despair : Spell
{
    public Despair(){
        spellName = "Despair";
        description = "Summon a manifestation of despair. The more your enemy gives in to despair, the more damage they take.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big dark damage, based on targets will instead of resistance
}
