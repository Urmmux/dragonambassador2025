using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Spell
{
    public Heal(){
        spellName = "Heal";
        description = "Heal a small amount";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //no strings-attached healing
}
