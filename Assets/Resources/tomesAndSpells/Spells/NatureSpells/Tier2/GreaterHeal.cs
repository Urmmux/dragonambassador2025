using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterHeal : Spell
{
    public GreaterHeal(){
        spellName = "Greater Heal";
        description = "Heal a decent amount of damage.";
        cooldown = 2;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //heals a lot more damage
}
