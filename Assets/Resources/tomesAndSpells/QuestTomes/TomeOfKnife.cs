using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfKnife : Tome
{
    void Awake(){
        tomeName = "Tome of Knife";
        description = "This tome has no spells, or even pages. It's kind of sharp.";
        spells = new Spell[3]
        {
            new Knife(),
            new DivineBlade(),
            new Wait()
        };
    }

}
