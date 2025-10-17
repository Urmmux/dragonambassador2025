using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfDice : Tome
{
    void Awake(){
        tomeName = "Tome of Dice";
        description = "Start small at first. Bet coins, bet laughs, bet stories. You can gamble with blood and bones once you're desperate.";
        spells = new Spell[3]
        {
            new EntropySpiral(),
            new Roulette(),
            new MagicTrick()
        };
    }

}
