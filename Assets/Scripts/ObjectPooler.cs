using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    // not really needed with the impromptu extending thats going on.
    public int poolSize;
    List<GameObject> pool;
    public GameObject parent;

    void Start()
    {
        //parent = GameObject.Find("Platforms");
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            addObject();
        }
    }

    private GameObject addObject()
    {
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.transform.parent = parent.transform;
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return addObject();
    }
}
