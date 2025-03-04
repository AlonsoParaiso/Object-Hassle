using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Vector3 spawn;
    public AudioClip deathAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            other.transform.position = spawn;//hace que spawnee donde se le diga
        }
    }
}
