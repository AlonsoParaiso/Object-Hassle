using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : Character
{
    public Mechero(string name, float damage, int health) : base("Mechero", 10, Resources.Load<GameObject>("Prefabs/Mechero"), 3)
    {

    }

    public override float Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(Vector3.forward, 5);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(owner.transform.position, 5);
    }
}
