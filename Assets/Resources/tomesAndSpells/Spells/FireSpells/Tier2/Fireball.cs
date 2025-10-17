using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    public Fireball(){
        spellName = "Fireball";
        description = "Hurl a ball of fire that explodes on impact.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big fire damage with a long cooldown
}
