using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    public GameObject poolingObject;
    public GameObject poolingObject_Christmas;
    public static int countID = 0;
    Queue<BOX> poolingObjectQueue = new Queue<BOX>();
    void Awake()
    {
        instance = this;
        Init(10); //초기 생성 수
    }

    private void Init(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateNewObject();
        }

        print("갯수 :" + poolingObjectQueue.Count);
    }
    private BOX CreateNewObject()
    {
        BOX newObj = null;
        if (DataManager.instance.boxSkinIndex == 0)
        {

            newObj = Instantiate(poolingObject).GetComponent<BOX>();
        }
        else if(DataManager.instance.boxSkinIndex == 1)
        {
            newObj = Instantiate(poolingObject_Christmas).GetComponent<BOX>();
        }
        newObj.gameObject.name += countID;
        countID++;
        newObj.gameObject.SetActive(false);
        newObj.gameObject.transform.SetParent(transform);

        poolingObjectQueue.Enqueue(newObj);

        return newObj;
    }

    public BOX GetObject()
    { // 오브젝트 생성 시 함수 사용 및 위치 지정
        if (instance.poolingObjectQueue.Count > 0)
        {
            var obj = instance.poolingObjectQueue.Dequeue();

            obj.gameObject.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            var newObj = instance.CreateNewObject();
            //newObj.gameObject.transform.SetParent(null);
            newObj.gameObject.transform.SetParent(this.transform);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    // 오브젝트를 다시 받아올 때 사용
    public void ReturnObject(BOX obj)
    { 
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.SetParent(transform);
        instance.poolingObjectQueue.Enqueue(obj);

        print("갯수 :" + poolingObjectQueue.Count);
    }
}