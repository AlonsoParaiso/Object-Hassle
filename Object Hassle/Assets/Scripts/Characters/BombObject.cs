using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public float maxTime, speed, throwForce;
    public AudioClip explosionAudio;

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
        rb.AddForce(((ownerTransform.localScale.x < 0 ? -ownerTransform.right : ownerTransform.right) + Vector3.up) * throwForce);
    }

    private void OnDisable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);
        bool hasHit = false;
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")) //Recorre cada elemento del array para ver si tocamos suelo
            {
                colliders[i].gameObject.GetComponent<PlayerMovement>().character.Knockback(colliders[i].gameObject.GetComponent<Rigidbody>(), transform, 10);
     

                Debug.Log("dar");
                AudioManager.instance.PlayAudio(explosionAudio, "explosion", false, 1f);

                hasHit = true;
            }
        }

        if (!hasHit)
        {
            AudioManager.instance.PlayAudio(explosionAudio, "explosion", false, 1f);
            Debug.Log("no dar");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}