using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : Character
{
    public Mechero(string name, float damage, float health) : base("Mechero", 10, Resources.Load<GameObject>("Prefabs/Capsule"), 100)
    {

    }

    public override float Attack()
    {
        throw new System.NotImplementedException();
    }
}
