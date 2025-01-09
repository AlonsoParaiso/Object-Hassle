using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : Character
{
    public Mechero(string name, float damage, int health) : base("Mechero", 10, Resources.Load<GameObject>("Prefabs/Mechero"), 3)
    {

    }

    public override float Attack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 1f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].GetComponent<PlayerManager>().GetCharacter().GetCharacterIndex() != characterIndex) //Recorre cada elemento del array para ver si tocamos suelo
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
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Gizmos.DrawWireSphere(vectorAttack, 0.5f);
    }

    public override void DrawGizmosSuperAttack(GameObject owner)
    {
        Gizmos.color = Color.magenta;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        Gizmos.DrawWireSphere(vectorAttack, 2);
        Gizmos.DrawWireSphere(new Vector3(vectorAttack.x + 25, vectorAttack.y, vectorAttack.z),2);
        Gizmos.DrawLine(vectorAttack, new Vector3(vectorAttack.x + 25, vectorAttack.y, vectorAttack.z));
    }

    public override float SpecialAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 0.5f);
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

    public override float SuperAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        Collider[] colliders = Physics.OverlapCapsule(vectorAttack,new Vector3( vectorAttack.x + 25, vectorAttack.y,vectorAttack.z ), 2 );
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
