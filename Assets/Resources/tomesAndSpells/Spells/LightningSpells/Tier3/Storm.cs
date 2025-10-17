using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : Spell
{
    public Storm(){
        spellName = "Storm";
        description = "Batter your enemies helpless with a storm of rain, wind, and hail.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflict wet, inflict vulnerable, inflict hail, inflict exhausted, inflict exposed
}
