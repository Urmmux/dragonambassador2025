using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStats : MonoBehaviour
{
    public string type;
    public string affinity;
    public int health;
    public int resistance;
    public int defense;
    public int tempPower;
    public int will;
    public List<StatusEffect> statusEffects = new List<StatusEffect>(); 
}
