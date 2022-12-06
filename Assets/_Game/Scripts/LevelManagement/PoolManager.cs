using UnityEngine;
using Pixelplacement;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PoolingItems
{
    public string poolingItemsName;
    public int poolCount;
    public GameObject poolingObject;
}
[System.Serializable]
public class PoolingList
{
    public string poolingItemsName;
    public List<GameObject> listOfPoolingObjects = new List<GameObject>();
}

public class PoolManager : Singleton<PoolManager>
{
    public List<PoolingItems> listOfPoolingItems = new List<PoolingItems>();
    public List<PoolingList> listOfPoolLists = new List<PoolingList>();
   

    private void Start()
    {
        
        foreach (PoolingItems pI in listOfPoolingItems)
        {
            listOfPoolLists.Add(new PoolingList());

            listOfPoolLists[listOfPoolLists.Count - 1].poolingItemsName = pI.poolingItemsName;

            for (int i = 0; i < pI.poolCount; i++)
            {
                GameObject poolingObj = Instantiate(pI.poolingObject, Vector3.zero, Quaternion.identity, transform);
                poolingObj.SetActive(false);
                listOfPoolLists[listOfPoolLists.Count - 1].listOfPoolingObjects.Add(poolingObj);
            }

        }
    }

    public GameObject GetPooledObject(string objName)
    {
        bool isTrueString = false;
        PoolingList poolList = new();
        foreach (PoolingList pL in listOfPoolLists)
        {
            if(pL.poolingItemsName == objName)
            {
                poolList = pL;
                isTrueString = true;
            }
        }

        if(!isTrueString)
        {
            Debug.Log("WrongString");
            return null;
        }
        else
        {
            
            GameObject pooledObj = poolList.listOfPoolingObjects[0];
            poolList.listOfPoolingObjects.RemoveAt(0);
            poolList.listOfPoolingObjects.Add(pooledObj);
            pooledObj.SetActive(true);
            return pooledObj;
        }

        
    }
}