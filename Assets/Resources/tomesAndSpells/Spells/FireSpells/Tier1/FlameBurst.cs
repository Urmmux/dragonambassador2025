using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBurst : Spell
{
    public FlameBurst(){
        spellName = "Flame Burst";
        description = "Create a sudden burst of flame.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //damage based on affinity and resistance of target
}
