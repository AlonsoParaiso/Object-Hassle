//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KombatController : MonoBehaviour
//{
//    Character character, enemy;
//    public Rigidbody rb;
//    GameObject ownerEnemy;
//    // Start is called before the first frame update
//    void Start()
//    {
//        character = GetComponent<Character>();
//        enemy = GetComponent<Character>();

//    }


//    void Update()
//    {
//        if (enemy.Attack(ownerEnemy))
//        {

//            Knockback(character);
//        }
//        else if (enemy.SuperAttack(ownerEnemy)==0)
//        {
//            Knockback(character);
//        }
//        else if (enemy.SpecialAttack(ownerEnemy)==0)
//        {
//            Knockback(character);
//        }
//    }
//    public void Knockback(Character character)
//    {
//        rb.AddForce(((transform.localScale.x < 0 ? transform.right : -transform.right) + Vector3.up) * (character.GetDamage() * character.GetHealth()));

//    }

//}
