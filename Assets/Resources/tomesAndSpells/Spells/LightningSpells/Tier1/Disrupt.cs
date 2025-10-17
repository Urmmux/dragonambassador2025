using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disrupt : Spell
{
    public Disrupt(){
        spellName = "Disrupt";
        description = "A sudden jolt that keeps your enemy from defending properly.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //ingores resistance and lowers defense
}
