using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Spell
{
    public Shock(){
        spellName = "Shock";
        description = "Touch and enemy and deliver a big charge of electricity.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //lightning damage
}
