using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KombatController : MonoBehaviour
{
    Character character, enemy;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        enemy = GetComponent<Character>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (enemy.Attack( ))
    //    {

    //        Knockback(character);
    //    }
    //    else if (enemy.SuperAttack())
    //    {
    //        Knockback(character);   
    //    }
    //    else if (enemy.SpecialAttack())
    //    {
    //        Knockback(character);
    //    }
    //}
    public void Knockback(Character character)
    {
        rb.AddForce(((transform.localScale.x < 0 ? transform.right : -transform.right) + Vector3.up) * (character.GetDamage() * character.GetHealth()));

    }

}
