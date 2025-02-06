using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody rb;
    private Character character;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>(); 
        character=GetComponent<Character>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if ()
            rb.AddForce((transform.forward + Vector3.up) * character.GetDamage());
    }
    void Update()
    {
       
    }
}
