using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingBarrage : Spell
{
    public FlamingBarrage(){
        spellName = "Flaming Barrage";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //AOE fire damage
}