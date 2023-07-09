using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    public List<ObjectPool> objectPools;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject ReleaseObject(ObjectID objectID)
    {
        ObjectPool objectPool = objectPools[(int)objectID];
        GameObject obj;

        if (objectPool.inactiveList.Count != 0)
        {
            obj = objectPool.inactiveList[0];
            objectPool.inactiveList.Remove(obj);
        }
        else
        {
            obj = Instantiate(objectPool.prefabVariants[Random.Range(0, objectPool.prefabVariants.Count)], transform);
        }
        objectPool.activeList.Add(obj);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        int temp = 15;

        SupportFunctions.MoveBetweenLists(objectPools[temp].activeList, objectPools[temp].inactiveList, obj);
    }
}

[System.Serializable]
public struct ObjectPool
{
    public List<GameObject> prefabVariants;
    public List<GameObject> inactiveList;
    public List<GameObject> activeList;
}

public enum ObjectID
{
    ES,NE,NES,NS,NW,NWE,NWES,NWS,WE,WES,WS,House,OfficeBase,OfficeLayer,OfficeTop,Snow,Ice
}