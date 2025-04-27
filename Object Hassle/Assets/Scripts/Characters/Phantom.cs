using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : Character
{
    public Phantom(string name, float damage, int health) : base("bad guy_sin rig 1", 10, Resources.Load<GameObject>("Prefabs/bad guy_sin rig 1"), 0)
    {

    }
    public override float Attack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 2f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 7);
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
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 2f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 7);
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
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 2f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReference playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReference>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 7);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

    

    public override void DrawGizmos(GameObject owner)
    {
        DrawGizmosAttack(owner);
        DrawGizmosUpAttack(owner);
        DrawGizmosDownAttack(owner);

        DrawGizmosSpAttack(owner);
        DrawGizmosSuperAttack(owner); ;
    }

    public override void DrawGizmosAttack(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Gizmos.DrawWireSphere(vectorAttack,1f);
    }

    public override void DrawGizmosDownAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override void DrawGizmosSpAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override void DrawGizmosSuperAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override void DrawGizmosUpAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override float SpecialAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override float SuperAttack(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

}

    

