using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyBomba : Character
{

    public ReyBomba(string name, float damage, float health) : base("Rey Bomba", 10, Resources.Load<GameObject>("Prefabs/reybomba"), 100) 
    { 
        
    }

}
