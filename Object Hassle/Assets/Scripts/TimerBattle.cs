using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBattle : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    public PlayerMovement player;

    void Start()
    {
        timer += Time.deltaTime;
        player=FindObjectOfType<PlayerMovement>();
        player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            player.gameObject.SetActive(true);
        }
    }
}
