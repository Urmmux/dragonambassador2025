using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornShot : Spell
{
    public ThornShot(){
        spellName = "Thorn Shot";
        description = "Shoots poisonous thorns at your enemy.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //some nature damage and inflicts poison
}
