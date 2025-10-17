using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfWildfire : Tome
{
    void Awake(){
        tomeName = "Tome of Wildfire";
        description = "A spark at first, then a fire, then a revolution. The grasslands burnt to ash, and new seeds took root.";
        spells = new Spell[3]
        {
            new FlameBurst(),
            new Inferno(),
            new EntropySpiral()
        };
    }

}
