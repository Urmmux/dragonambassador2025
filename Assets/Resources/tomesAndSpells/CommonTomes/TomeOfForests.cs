using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfForests : Tome
{
    void Awake(){
        tomeName = "Tome of Forests";
        description = "The oldest tree grows up from the oceans far to the west, and the wind carries its seedlings here.";
        spells = new Spell[3]
        {
            new Roots(),
            new ThornArmor(),
            new MetalScreen()
        };
    }

}
