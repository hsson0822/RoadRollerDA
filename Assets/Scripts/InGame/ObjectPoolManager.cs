using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{

    static ObjectPoolManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        PoolInit();
    }

    public static ObjectPoolManager GetInstance()
    {
        return instance;
    }

    public ObjectPool carPool;

    public void PoolInit()
    {
        carPool.AllocateCars();
        
    }
}
