using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindRead : Spell
{
    public MindRead(){
        spellName = "Mind Read";
        description = "Read the mind of your enemies, dodging any attack for a moment.";
        cooldown = 2;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //caster gains invulnerable for 1 turn
}
