using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : Spell
{
    public IceSpike(){
        spellName = "Ice Spike";
        description = "Conjure a jagged pillar of ice from the ground.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //ice damage that targets defense instead of resistance, can inflict bleed
}
