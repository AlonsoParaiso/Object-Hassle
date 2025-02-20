using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Character
{
    private string _name;
    private GameObject _gameObject;
    protected float damage;
    private float health;
    private float damageReceived;
    protected uint characterIndex;

    public Character() { }
    public Character(string name,float damage, GameObject gameObject, float health) 
    {
        _name = name;
        this.damage = damage;
        _gameObject = gameObject;
        this.health = health;
        
    }

    public string GetName() { return _name; }
    public float GetDamage() { return damage; }
    public GameObject GetGameObject() { return _gameObject; }
    public float GetHealth() { return health; } 

    public abstract float Attack(GameObject owner);

    public abstract float SpecialAttack(GameObject owner);

    public abstract float SuperAttack(GameObject owner);// programar objeto de super y cuando reciba X daño

    public abstract void DrawGizmos(GameObject owner);

    public abstract void DrawGizmosAttack(GameObject owner);

    public abstract void DrawGizmosSpAttack(GameObject owner);

    public abstract void DrawGizmosSuperAttack(GameObject owner);

    public void SetCharacterIndex(uint value) { this.characterIndex = value; }

    public uint GetCharacterIndex() { return characterIndex; }

    public void Knockback(Rigidbody rb, Transform transform,float damage)//hace que cadda vez que le pegues vaya yendose más para atrás cada vez
    {
        Vector3 force = ((transform.localScale.x < 0 ? -Vector3.right : Vector3.right) + Vector3.up) *(damage * GetHealth());
        rb.AddForce(force);
        rb.GetComponent<PlayerMovement>().kk1();
        health += damage;

    }




}
