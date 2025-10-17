using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheMammoth : Tome
{
    void Awake(){
        tomeName = "Tome of the Mammoth";
        description = "Bones of the mammoth are found deep in mountain caves, covered with frost.";
        spells = new Spell[3]
        {
            new IceBolt(),
            new Slush(),
            new LongBlade()
        };
    }

}
