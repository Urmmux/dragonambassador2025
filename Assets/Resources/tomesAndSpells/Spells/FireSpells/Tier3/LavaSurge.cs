using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurge : Spell
{
    public LavaSurge(){
        spellName = "Lava Surge";
        description = "A surge of molten rock erupts from under the feet of your enemy. It's hot enough that fire resistance doesn't matter, and might burn the target.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //damaging fire spell that inflicts burn, ignores resistance to fire
}
