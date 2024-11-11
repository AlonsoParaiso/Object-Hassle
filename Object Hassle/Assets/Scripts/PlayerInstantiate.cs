using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviour
{
    private GameObject player;
    void Awake()
    {
        player = GameManager.instance.character.GetGameObject();

        Instantiate(player,new Vector3(-6.23999977f, 2.32999992f, -2.50999999f),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
