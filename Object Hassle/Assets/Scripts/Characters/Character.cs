using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Character
{
    private string _name;
    private GameObject _gameObject;
    protected float damage;
    private int healht;
    private float damageReceived;
    protected uint characterIndex;

    public Character() { }
    public Character(string name,float damage, GameObject gameObject, int healht) 
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

    public abstract float SuperAttack(GameObject owner);// programar objeto de super y cuando reciba X daño

    public abstract void DrawGizmos(GameObject owner);

    public abstract void DrawGizmosAttack(GameObject owner);

    public abstract void DrawGizmosSpAttack(GameObject owner);

    public abstract void DrawGizmosSuperAttack(GameObject owner);

    public void SetCharacterIndex(uint value) { this.characterIndex = value; }

    public uint GetCharacterIndex() { return characterIndex; }

    


}
