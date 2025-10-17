using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchGrasp : Spell
{
    public EldritchGrasp(){
        spellName = "Edritch Grasp";
        description = "Open a window for a minor eldritch being to attack your enemy.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //deals void damage, targets defense instead of resistance
}
