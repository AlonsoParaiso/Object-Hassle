using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private string _name;
    private Mesh _sprite;
    protected float damage;

    public Character() { }
    public Character(string name,float damage, Mesh sprite) 
    {
        _name = name;
        this.damage = damage;
        _sprite = sprite;


    }

    public virtual float Attack() { return damage; }
}
