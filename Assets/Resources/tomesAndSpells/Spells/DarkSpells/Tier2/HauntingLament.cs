using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntingLament : Spell
{
    public HauntingLament(){
        spellName = "Haunting Lament";
        description = "Call upon the mourning of the dead to inflict haunted and cursed.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts haunted and cursed
}
