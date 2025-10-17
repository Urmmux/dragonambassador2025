using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overload : Spell
{
    public Overload(){
        spellName = "Overload";
        description = "Causes a buildup of electric energy in the target, inflicting overloaded.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //lightning damage and inflict overloaded for 3 turns
}
