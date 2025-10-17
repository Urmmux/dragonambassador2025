using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : Spell
{
    public Detonate(){
        spellName = "Detonate";
        description = "Release the magic bound in every effect on your enemy in a giant explosion.";
        cooldown = 5;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //removes all status effects on target and does damage for each
}
