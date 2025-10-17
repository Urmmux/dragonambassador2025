using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheKnight : Tome
{
    void Awake(){
        tomeName = "Tome of the Knight";
        description = "There's less and less true knights each year, without royalty to ordain them.";
        spells = new Spell[3]
        {
            new Blade(),
            new MetalScreen(),
            new Kindle()
        };
    }

}
