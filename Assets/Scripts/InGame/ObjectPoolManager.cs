using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{

    static ObjectPoolManager instance;
    public static ObjectPoolManager Instance { get; }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        PoolInit();
    }


    public ObjectPool carPool;

    public void PoolInit()
    {
        carPool.AllocateCars();
        
    }
}
