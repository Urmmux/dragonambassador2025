using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleBarrage : Spell
{
    public IcicleBarrage(){
        spellName = "Icicle Barrage";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //AOE frost damage
}