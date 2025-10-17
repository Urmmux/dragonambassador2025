using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfChitin : Tome
{
    void Awake(){
        tomeName = "Tome of Chitin";
        description = "Cobwebs lined the ceiling of the castle, while termites bore through the walls.";
        spells = new Spell[3]
        {
            new MetalScreen(),
            new InsectSwarm(),
            new Reflection()
        };
    }

}
