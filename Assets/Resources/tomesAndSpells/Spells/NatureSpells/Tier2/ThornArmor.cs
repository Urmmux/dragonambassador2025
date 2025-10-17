using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : Spell
{
    public ThornArmor(){
        spellName = "Thorn Armor";
        description = "Grants the target armor made of thorns, but poisons them in the process";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //poisons target, but gives them thorn armor
}
