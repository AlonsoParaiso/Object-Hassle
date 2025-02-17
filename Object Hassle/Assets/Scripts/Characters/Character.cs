using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Character
{
    private string _name;
    private GameObject _gameObject;
    protected float damage;
    private float healht;
    private float damageReceived;
    protected uint characterIndex;

    public Character() { }
    public Character(string name,float damage, GameObject gameObject, float healht) 
    {
        _name = name;
        this.damage = damage;
        _gameObject = gameObject;
        this.healht = healht;
        
    }

    public string GetName() { return _name; }
    public float GetDamage() { return damage; }
    public GameObject GetGameObject() { return _gameObject; }
    public float GetHealth() { return healht; } 

    public abstract float Attack(GameObject owner);

    public abstract float SpecialAttack(GameObject owner);

    public abstract float SuperAttack(GameObject owner);// programar objeto de super y cuando reciba X da�o

    public abstract void DrawGizmos(GameObject owner);

    public abstract void DrawGizmosAttack(GameObject owner);

    public abstract void DrawGizmosSpAttack(GameObject owner);

    public abstract void DrawGizmosSuperAttack(GameObject owner);

    public void SetCharacterIndex(uint value) { this.characterIndex = value; }

    public uint GetCharacterIndex() { return characterIndex; }

    public void Knockback(Rigidbody rb, Transform transform,float damage)
    {
        rb.AddForce(((transform.localScale.x < 0 ? transform.right : -transform.right) + Vector3.up) * (damage * GetHealth()));
        healht += damage;

    }




}
