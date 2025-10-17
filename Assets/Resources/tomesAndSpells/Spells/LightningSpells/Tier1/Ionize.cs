using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ionize : Spell
{
    public Ionize(){
        spellName = "Ionize";
        description = "Converts all attacks the target does into electric attacks.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts ionized -all damage from target counts as electric damage, applies to caster as well
}
