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

    public abstract float Attack();

    public abstract void DrawGizmos(GameObject owner);


}
