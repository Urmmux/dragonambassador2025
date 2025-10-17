using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachFromBeyond : Spell
{
    public override void Cast(GameObject caster, GameObject target) {}
    //big void damage, inflict exposed, targets defense instead of resistance

    public ReachFromBeyond(){
        spellName = "Reach From Beyond";
        description = "Invites a terrible entity from another world a brief window to attack your enemy.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
}
