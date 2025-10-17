using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfSummer : Tome
{
    void Awake(){
        tomeName = "Tome of Summer";
        description = "The songs, ones that can only be sung with forgotten pronounciations, that the Numians used to dance with to celebrate the day.";
        spells = new Spell[3]
        {
            new Heal(),
            new ThornShield(),
            new InsectSwarm()
        };
    }

}
