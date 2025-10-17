using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfGraves : Tome
{
    void Awake(){
        tomeName = "Tome of Graves";
        description = "Old memories still cling to those sacred stones, even after the bodies have all rotted away.";
        spells = new Spell[3]
        {
            new HauntingLament(),
            new ThornArmor(),
            new Despair()
        };
    }

}
