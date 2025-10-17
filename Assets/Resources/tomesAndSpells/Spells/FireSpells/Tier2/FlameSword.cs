using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSword : Spell
{
    public FlameSword(){
        spellName = "Flame Sword";
        description = "Conjure a flaming sword and hurl it at an enemy.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //fire attack that targets defense instead of resistance
}
