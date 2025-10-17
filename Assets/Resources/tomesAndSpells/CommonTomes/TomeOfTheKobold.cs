using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheKobold : Tome
{
    void Awake(){
        tomeName = "Tome of the Kobold";
        description = "Scaly cavern creatures, their obsessions scrawled on rat-skins and stored in stony vaults, hoping one day to lift them to the skies.";
        spells = new Spell[3]
        {
            new Shock(),
            new Disrupt(),
            new EmotionSurge()
        };
    }

}
