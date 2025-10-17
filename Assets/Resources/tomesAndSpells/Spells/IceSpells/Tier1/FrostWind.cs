using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWind : Spell
{
    public FrostWind(){
        spellName = "Frost Wind";
        description = "Blast your enemy with a torrent of freezing wind.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts exposed
}
