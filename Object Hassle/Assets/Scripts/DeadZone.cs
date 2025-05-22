using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Vector3 spawn;
    public AudioClip deathAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() || other.GetComponent<PlayerMovementPun>())
        {
            other.transform.position = spawn;//hace que spawnee donde se le diga
            other.GetComponent < PlayerMovement>().character.SetHealth(0);
            other.GetComponent<PlayerMovement>().life -= 1;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
