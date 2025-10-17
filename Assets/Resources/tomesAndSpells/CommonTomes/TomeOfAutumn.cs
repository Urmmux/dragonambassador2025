using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfAutumn : Tome
{
     void Awake(){
        tomeName = "Tome of Autumn";
        description = "The pillars of Nume began to crumble and wear, leaving stone dust around the palaces. The warmth of the Numian bonfire began to fade.";
        spells = new Spell[3]
        {
            new SpitefulElegy(),
            new FrostWind(),
            new RustCloud()
        };
    }
}
