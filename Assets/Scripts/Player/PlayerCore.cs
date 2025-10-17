using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    //store stats to assign to battlestats as well has store and manage tomes
    public int health = 10;
    public int resistance = 4;
    public int defense = 4;
    public int power = 4;
    public int will = 4;
    public Tome[] tomeArr = new Tome[3];

    public string playerName = "Shrive";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
