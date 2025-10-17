using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tome : MonoBehaviour
{
    public string tomeName;
    public string description;
    public Spell[] spells = new Spell[3];

}
