using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfRest : Tome
{
    void Awake(){
        tomeName = "Tome of Rest";
        description = "Don't forget to breathe.";
        spells = new Spell[3]
        {
            new Gravity(),
            new SnowFall(),
            new StillMind()
        };
    }

}
