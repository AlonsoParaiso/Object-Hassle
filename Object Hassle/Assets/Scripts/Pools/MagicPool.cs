using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPool : MonoBehaviour
{
    public GameObjectPool magicPool;
    public float maxTime;
    public PoolType poolTypeToSearch;

    private float currenTime;
    // Start is called before the first frame update
    void Start()
    {
        GameObjectPool[] pools = FindObjectsOfType<GameObjectPool>();//busca el objecto en la scene de gameobjectPool

        foreach (GameObjectPool pool in pools)
        {
            if (pool.poolType == poolTypeToSearch)
            {
                magicPool = pool;
                break;
            }
        }

    }
}
