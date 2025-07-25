using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    Stack<PoolableObject> objStack;
    public PoolableObject[] obj;

    public int allocateCount;

    public void Start()
    {
        obj = new PoolableObject[4];
    }

    public void AllocateCars()
    {
        objStack = new Stack<PoolableObject>();

        for (int t = 0; t < obj.Length; ++t)
        {
            for (int i = 0; i < allocateCount; ++i)
            {
                PoolableObject objTemp = null;

                objTemp = Instantiate(obj[t], transform);

                objTemp.SetPool(this);
                objStack.Push(objTemp);
            }
        }
    }

    public PoolableObject PopObject()
    {
        PoolableObject tempObj = null;

        if (objStack.Count > 0)
        {
            tempObj = objStack.Pop();
            tempObj.gameObject.SetActive(true);
        }

        return tempObj;
    }

    public void PushObject(PoolableObject obj)
    {
        obj.gameObject.SetActive(false);
        objStack.Push(obj);
    }
}
