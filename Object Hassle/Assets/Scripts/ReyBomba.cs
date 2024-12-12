using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ReyBomba : Character
{

    public ReyBomba(string name, float damage, int health) : base("Rey Bomba", 10, Resources.Load<GameObject>("Prefabs/ReyBomba"), 3) 
    { 
        
    }

    public override float Attack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Collider [] colliders = Physics.OverlapSphere(vectorAttack, 0.5f);
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
        DrawGizmosAttack(owner);
        DrawGizmosSpAttack(owner);
        DrawGizmosSuperAttack(owner);
    }

    public override void DrawGizmosAttack(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Gizmos.DrawWireSphere(vectorAttack, 1f);
    }

    public override void DrawGizmosSpAttack(GameObject owner)
    {
        Gizmos.color = Color.blue;
    }

    public override void DrawGizmosSuperAttack(GameObject owner)
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(owner.transform.position, 7);
    }

    public override float SpecialAttack(GameObject owner)
    {
        return 0;
    }

    public override float SuperAttack(GameObject owner)
    {
        Collider[] colliders = Physics.OverlapSphere(owner.transform.position, 7);
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
}
