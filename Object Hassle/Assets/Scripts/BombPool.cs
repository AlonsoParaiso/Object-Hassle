using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public GameObjectPool bombPool;
    public float maxTime;
    public PoolType poolTypeToSearch;

    private float currentTime;


    private void Start()
    {
        GameObjectPool[] pools = FindObjectsOfType<GameObjectPool>();

        foreach (GameObjectPool pool in pools)
        {
            if(pool.poolType == poolTypeToSearch)
            {
                bombPool = pool;
                break;
            }
        }

        BombSpawn();
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            BombSpawn();
            currentTime = 0;
        }

    }

    void BombSpawn()
    {
        GameObject obj = bombPool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);
            obj.transform.position = transform.position;

            
        }

    }
}
