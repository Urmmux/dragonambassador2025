using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheVisitor : Tome
{
    void Awake(){
        tomeName = "Tome of the Visitor";
        description = "It sounded like him, acted like him, but it was all the wrong shapes.";
        spells = new Spell[3]
        {
            new EldritchGrasp(),
            new Vestige(),
            new Slush()
        };
    }

}
