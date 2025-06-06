using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
using Photon.Pun;
using Photon.Realtime;

public class ReyBombaPun : CharacterPun
{

    public ReyBombaPun(string name, float damage, int health) : base("Rey Bomba", 10, Resources.Load<GameObject>("Photon/ReyBomba"), 0) 
    { 
        
    }

    public override float Attack(GameObject owner)
    {
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y;
        vectorAttack.x += owner.transform.localScale.x;
        Collider [] colliders = Physics.OverlapSphere(vectorAttack, 1f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReferencePun playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReferencePun>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 8);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }

    public override float UpAttack(GameObject owner)
    {

        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y += owner.transform.localScale.y*3;
        Collider[] colliders = Physics.OverlapSphere(vectorAttack, 1f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReferencePun playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReferencePun>();
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
                CharacterReferencePun playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReferencePun>();
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
        DrawGizmosUpAttack(owner);
        DrawGizmosDownAttack(owner);

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
        vectorAttack.y += owner.transform.localScale.y*3;
       
        Gizmos.DrawWireSphere(vectorAttack, 1f);
    }

    public override void DrawGizmosDownAttack(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Vector3 vectorAttack = owner.transform.position;
        vectorAttack.y -= owner.transform.localScale.y;

        Gizmos.DrawWireSphere(vectorAttack,1f);
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

        BombSpawn(owner.transform, owner.GetComponent<BombPool>().bombPool);
        return 0;
    }

    public override float SuperAttack(GameObject owner)
    {
        Collider[] colliders = Physics.OverlapSphere(owner.transform.position, 7);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")
                && colliders[i].gameObject != owner) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Debug.Log("dar");
                CharacterReferencePun playerManagerEnemy = colliders[i].gameObject.GetComponent<CharacterReferencePun>();
                playerManagerEnemy.character.Knockback(playerManagerEnemy.gameObject.GetComponent<Rigidbody>(), owner.transform, 25);
                return damage;
            }
        }
        Debug.Log("no dar");
        return 0;
    }


    void BombSpawn(Transform transform, GameObjectPool bombPool)
    {
        GameObject obj = bombPool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);

            Vector3 vectorAttack = transform.position;
            vectorAttack.y += transform.localScale.y;
            vectorAttack.x += transform.localScale.x;
            obj.transform.position = vectorAttack;

            BombObject bombObjectComponent = obj.GetComponent<BombObject>();
            bombObjectComponent.ResetVelocity();
            bombObjectComponent.ApplyParabolicThrow(transform);

        }
    }
}
