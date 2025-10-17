using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrick : Spell
{
    public MagicTrick(){
        spellName = "Magic Trick";
        description = "Not real magic, but clever sleight of hand. Use this to steal an item.";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //adds an item to the player inventory based on location. If in a lair, remove item from the lair
}
