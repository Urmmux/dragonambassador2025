using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionSurge : Spell
{
    public EmotionSurge(){
        spellName = "Emotion Surge";
        description = "Your ally increases their will, depending on how they feel about you.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //increase will based on affection toward player
}
