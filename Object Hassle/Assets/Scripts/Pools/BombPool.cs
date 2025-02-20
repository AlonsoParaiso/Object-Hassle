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
        GameObjectPool[] pools = FindObjectsOfType<GameObjectPool>();//busca el objecto en la scene de gameobjectPool

        foreach (GameObjectPool pool in pools)
        {
            if(pool.poolType == poolTypeToSearch)
            {
                bombPool = pool;
                break;
            }
        }

        
    }
}
