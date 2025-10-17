using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornShield : Spell
{
    public ThornShield(){
        spellName = "Thorn Shield";
        description = "Aplies a thorny shield that damages attackers if they come into contact with it.";
        cooldown = 0;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //applies thornshield to caster, damages attackers on contact
}
