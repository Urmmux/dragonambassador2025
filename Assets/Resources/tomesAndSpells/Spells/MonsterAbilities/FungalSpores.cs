using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungalSpores : Spell
{
    public FungalSpores(){
        spellName = "Fungal Spores";
        description = "";
        cooldown = 2;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //AOE nature damage, big poison, exposed
}
