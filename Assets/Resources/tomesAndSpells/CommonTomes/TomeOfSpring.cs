using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfSpring : Tome
{
    void Awake(){
        tomeName = "Tome of Spring";
        description = "The halls started small, as an escape from the people of Quarrash. Food, water, and fire, grew the halls into an empire.";
        spells = new Spell[3]
        {
            new Slush(),
            new Dampener(),
            new ThornShot()
        };
    }

}
