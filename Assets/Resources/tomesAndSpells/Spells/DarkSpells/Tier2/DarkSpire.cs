using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSpire : Spell
{
    public DarkSpire(){
        spellName = "Dark-Spire";
        description = "Conjure a tower of shadows and collapse it on to your enemy.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //moderate dark damage
}
