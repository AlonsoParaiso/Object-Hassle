using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Character
{
    private string _name;
    private GameObject _gameObject;
    protected float damage;
    private float healht;

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

    public virtual float Attack() { return damage; }
}
