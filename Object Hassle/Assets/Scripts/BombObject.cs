using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public float maxTime, speed, trowForce;

    private float currentTime;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
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
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(1,1,0)* trowForce);
    }
}
