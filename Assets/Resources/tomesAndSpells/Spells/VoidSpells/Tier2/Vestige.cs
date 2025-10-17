using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vestige : Spell
{
    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts haunted, as well as two random status from [burn, hail, overloaded, wet, exposed, and egobind]

    public Vestige(){
        spellName = "Vestige";
        description = "Invoke something left behind. Inflicts haunted, and two other status effects.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
}
