using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfEmbers : Tome
{
    void Awake(){
        tomeName = "Tome of Embers";
        description = "Fire stolen from the titans, tended by the dragons, and studied by the mortals.";
        spells = new Spell[3]
        {
            new AshFall(),
            new Kindle(),
            new FlameBurst()
        };
    }

}
