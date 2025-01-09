using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public float maxTime, speed, trowForce;

    private float currentTime;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }

    public void ApplyParabolicThrow(Transform ownerTransform)
    {
        rb.AddForce(((ownerTransform.localScale.x < 0 ? -ownerTransform.right : ownerTransform.right) + Vector3.up) * trowForce);
    }

    private void OnDisable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Character character = colliders[i].GetComponent<Character>();
                character.GetDamage();
                Debug.Log("dar");
            }
        }
        Debug.Log("no dar");

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}