using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class Wraith : Character
{
    private float superDistance = 3f;
    public Wraith(string name, float damage, int health) : base("Wraith", 10, Resources.Load<GameObject>("Prefabs/Wraith"), 0)
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
        vectorAttack.y += owner.transform.localScale.y * 2;
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
        Gizmos.color = Color.magenta;
    }

    public override void DrawGizmosSuperAttack(GameObject owner)
    {
        Gizmos.color = Color.magenta;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.x += owner.transform.localScale.x;
        vectorAttack.y += owner.transform.localScale.y;
        Gizmos.DrawWireCube(new Vector3(vectorAttack.x, vectorAttack.y, vectorAttack.z), new Vector3(3, 20, 5));
    }


    public override float SpecialAttack(GameObject owner)
    {
        MagicSpawn(owner.transform, owner.GetComponent<MagicPool>().magicPool);
        return 0;
    }

    public override float SuperAttack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        Collider[] colliders = Physics.OverlapBox(new Vector3(vectorAttack.x + superDistance, vectorAttack.y, vectorAttack.z), new Vector3(3, 20, 5), Quaternion.identity);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != owner) 
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

    void MagicSpawn(Transform transform, GameObjectPool magicPool)
    {
        GameObject obj = magicPool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);

            Vector3 vectorAttack = transform.position;
            vectorAttack.y += transform.localScale.y;
            vectorAttack.x += transform.localScale.x;
            obj.transform.position = vectorAttack;

            MagicObject magicObjectComponent = obj.GetComponent<MagicObject>();
            magicObjectComponent.ResetVelocity();
            magicObjectComponent.SetDirection(transform);
            

        }
    }

}

    

