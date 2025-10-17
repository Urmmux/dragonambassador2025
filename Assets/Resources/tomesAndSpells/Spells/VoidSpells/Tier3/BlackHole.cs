using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Spell
{
    public override void Cast(GameObject caster, GameObject target) {}
    //immense void damage to target, moderate void damage to caster, and heavy on both

    public BlackHole(){
        spellName = "Black Hole";
        description = "Causes a gravitational anomaly on the battlefield, dealing damage, and inflictine exhaustion and heavy on both you and your target.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
}
