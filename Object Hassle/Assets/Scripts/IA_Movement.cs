using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Movement : MonoBehaviour
{
    public float speed, jumpForce;
    public int maxJumps;

    public GameObject player;

    private Vector3 dir;
    private int currentJumps = 0;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, 1.5f, transform.position.z), speed * Time.deltaTime);
        dir= target.transform.position - transform.position;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            StopCoroutine(kk());
            StartCoroutine(kk());
        }
    }

    IEnumerator kk()
    {
        yield return new WaitForSeconds(.5f);
        for(currentJumps = 0; currentJumps < maxJumps; currentJumps++)
        {
            if (dir.x < -0.1)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-5, jumpForce, 0), ForceMode.Impulse);
                yield return new WaitForSeconds(.5f);

            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(5, jumpForce, 0), ForceMode.Impulse);
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}
