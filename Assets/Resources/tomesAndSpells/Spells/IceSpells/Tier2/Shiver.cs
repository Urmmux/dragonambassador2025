using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiver : Spell
{
    public Shiver(){
        spellName = "Shiver";
        description = "A terrible chill that leaves the enemy vulnerable to any status effect.";
        cooldown = 5;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //bypassas resistance to gaurantee inflict vulnerable(status effects always hit)
}
