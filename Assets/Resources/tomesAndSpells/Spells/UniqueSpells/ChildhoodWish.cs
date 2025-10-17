using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildhoodWish : Spell
{
    public ChildhoodWish(){
        spellName = "Childhood Wish";
        description = "Brings back a memory of something you wanted as a kid.";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //base - give "desire" status effect to caster
    //if has caster has status "comfort", override and remove exhausted, comfortable, and increase will
    //if has caster has status "bitterness", override, deal damage to caster, and give thornshield with a huge magnitude
}
