using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public string monName;
    public List<Spell> abilities;
    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<Spell>();
        MonsterLibrary.AssignAbilities(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
