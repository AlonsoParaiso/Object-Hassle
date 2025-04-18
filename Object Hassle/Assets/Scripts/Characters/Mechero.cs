using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : Character
{
    public float superDistance = 25;

    public float superRadio = 2;

    public Mechero(string name, float damage, int health) : base("Mechero", 5, Resources.Load<GameObject>("Prefabs/Mechero"), 0)
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
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 5);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }
    public override float UpAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y * 3;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 1f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 8);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

    public override float DownAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y -= owner.transform.localScale.y;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 1f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 8);
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
    public override void DrawGizmosUpAttack(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y * 3;

        Gizmos.DrawWireSphere(vectorAttack, 1f);
    }

    public override void DrawGizmosDownAttack(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y -= owner.transform.localScale.y;

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
        vectorAttack.x += owner.transform.localScale.x;
        vectorAttack.y += owner.transform.localScale.y;
        Gizmos.DrawWireSphere(vectorAttack, 2);
        Gizmos.DrawWireSphere(new Vector3(vectorAttack.x + (owner.transform.localScale.x / Mathf.Abs(owner.transform.localScale.x) * superDistance), vectorAttack.y, vectorAttack.z), superRadio );
        Gizmos.DrawLine(vectorAttack, new Vector3(vectorAttack.x + (owner.transform.localScale.x / Mathf.Abs(owner.transform.localScale.x) * superDistance), vectorAttack.y, vectorAttack.z));
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
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 12);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

    public override float SuperAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.x += owner.transform.localScale.x;
        vectorAttack.y += owner.transform.localScale.y;
        Collider[] colliders = Physics.OverlapCapsule(vectorAttack,new Vector3( vectorAttack.x + superDistance, vectorAttack.y,vectorAttack.z ), superRadio );
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player") && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 20);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

}
