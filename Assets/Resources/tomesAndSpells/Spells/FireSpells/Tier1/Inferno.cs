using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inferno : Spell
{
    public Inferno(){
        spellName = "Inferno";
        description = "A sheet of flame ripples out, catching everything on fire.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts burn on both player and target, ignoring resistance
}
