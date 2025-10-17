using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnitFlesh : Spell
{
    public KnitFlesh(){
        spellName = "Knit Flesh";
        description = "";
        cooldown = 3;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //caster-only, heal and gain regeneration
}
