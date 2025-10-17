using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : Spell
{
    public Pulse(){
        spellName = "Pulse";
        description = "An electric attack that does extra damage against electric-affinity enemies.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //lightning damage, do extra damage against lightning affinity
}
