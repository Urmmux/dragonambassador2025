using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheChampion : Tome
{
    void Awake(){
        tomeName = "Tome of the Champion";
        description = "Having been knighted by the late king, disowned by the academy, and exiled from the Vill, she took up her own path.";
        spells = new Spell[3]
        {
            new LongBlade(),
            new VerdantPact(),
            new DarkSpire()
        };
    }

}
