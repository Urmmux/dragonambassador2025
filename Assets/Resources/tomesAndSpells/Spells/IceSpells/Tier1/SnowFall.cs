using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFall : Spell
{
    public SnowFall(){
        spellName = "Snow-Fall";
        description = "Gentle snow-fall creates an aura of silence around a target.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts silent for 1 turn
}
