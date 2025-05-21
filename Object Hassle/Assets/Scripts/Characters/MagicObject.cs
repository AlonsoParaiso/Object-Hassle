using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicObject : MonoBehaviour
{
    public float speed;
    public float maxTime;
    public float throwForce = 3;

    private Rigidbody rb;
    private float currentTime;
    private Vector3 dir;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime) 
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

    private void FixedUpdate()
    {
        rb.velocity = speed * dir;
    }

    private void OnDisable() 
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, 6);
        bool hasHit = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.GetComponent<PlayerMovement>().character.Knockback(colliders[i].gameObject.GetComponent<Rigidbody>(), transform, 8);

            Debug.Log("dar");
            hasHit = true;
        }

        if (!hasHit)
        {
            Debug.Log("no dar");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public void SetDirection(Transform ownerTransform)
    {
        rb.AddForce(ownerTransform.localScale.x < 0 ? -ownerTransform.right : ownerTransform.right);
    }
}
