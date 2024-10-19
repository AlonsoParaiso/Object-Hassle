using System.Collections;
using System.Collections.Generic;
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

    public virtual float Attack() { return damage; }
}
