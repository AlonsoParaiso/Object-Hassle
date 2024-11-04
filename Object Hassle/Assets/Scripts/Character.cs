using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Character
{
    private string _name;
    private Mesh _sprite;
    protected float damage;
    private float healht;

    public Character() { }
    public Character(string name,float damage, Mesh sprite,float healht) 
    {
        _name = name;
        this.damage = damage;
        _sprite = sprite;
        this.healht = healht;
    }

    public string GetName() { return _name; }
    public float GetDamage() { return damage; }
    public Mesh GetSprite() { return _sprite; }

    public virtual float Attack() { return damage; }
}
