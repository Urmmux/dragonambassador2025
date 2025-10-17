using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheLeviathan : Tome
{
    void Awake(){
        tomeName = "Tome of Leviathan";
        description = "Under the surface of the waters swam a shape so impossibly long, we feared it might never stop. When the great body of the beast broke the water, our ships capsized. I do not know what happened to the rest of the crew.";
        spells = new Spell[3]
        {
            new Blizzard(),
            new IceBolt(),
            new Despair()
        };
    }

}
