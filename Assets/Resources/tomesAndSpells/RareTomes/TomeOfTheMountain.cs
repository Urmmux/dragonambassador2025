using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheMountain : Tome
{
    void Awake(){
        tomeName = "Tome of the Mountain";
        description = "The first recorded spells were on great murals, carved into the side of the peaks of the mountains. Traces of the original spells crack the ice every few years, and cause avalanches.";
        spells = new Spell[3]
        {
            new GreaterHeal(),
            new Blizzard(),
            new Gravity()
        };
    }

}
