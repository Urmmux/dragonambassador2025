using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedGrowth : Spell
{
    public WeedGrowth(){
        spellName = "Weed Growth";
        description = "Causes weeds to sprout from the target, draining their energy and exhausting them.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts exhausted, if the target is wet, deals nature damage as well
}
