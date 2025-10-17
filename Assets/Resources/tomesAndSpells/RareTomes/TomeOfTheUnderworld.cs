using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheUnderworld : Tome
{
    void Awake(){
        tomeName = "Tome of the Underworld";
        description = "The champion questioned why would the sinners be punished after death. What more could the guilty do? What harm in letting them be; in justice left undone?";
        spells = new Spell[3]
        {
            new DevouringPit(),
            new LavaSurge(),
            new IceSpike()
        };
    }

}
