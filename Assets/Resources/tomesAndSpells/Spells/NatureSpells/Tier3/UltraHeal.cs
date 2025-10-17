using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraHeal : Spell
{
    public UltraHeal(){
        spellName = "Ultra Heal";
        description = "Knit back together flesh and bone, granting a miraculous recovery";
        cooldown = 5;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //heals a ton of damage, but exhausts the caster
}
