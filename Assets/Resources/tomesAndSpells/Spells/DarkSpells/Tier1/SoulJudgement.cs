using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulJudgement : Spell
{
    public SoulJudgement(){
        spellName = "Soul Judgement";
        description = "Smite a portion of the target's soul, but if you were found unworthy, you take an equal amount of damage.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //if caster has less health than the target, deal dark damage to caster, either way, deal dark damage to target
}
