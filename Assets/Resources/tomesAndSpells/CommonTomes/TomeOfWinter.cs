using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfWinter : Tome
{
    void Awake(){
        tomeName = "Tome of Winter";
        description = "The lands of Nume were quiet and still. The courtyards, once full of sunlight and conversation, would wait for their season once more.";
        spells = new Spell[3]
        {
            new SnowFall(),
            new IceSpike(),
            new Heal()
        };
    }

}
