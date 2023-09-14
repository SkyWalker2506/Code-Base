using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem
{
    public class Pool<T> : IPool where T : MonoBehaviour, IPoolObj 
    {
        private T poolObjPrefab;
        private int batchAmount;
        public Stack<IPoolObj> AllObjects { get; set; }
        public Stack<IPoolObj> AvailableObjects { get; set; }


        public Pool(IPoolData<T> poolData)
        {
            poolObjPrefab = poolData.PoolObjPrefab;
            batchAmount = poolData.BatchAmount;
            AllObjects = new Stack<IPoolObj>();
            AvailableObjects = new Stack<IPoolObj>();
            CreateBatch(poolData.FirstCreatedAmount);            
        }
        
        public void CreateBatch(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IPoolObj poolObj = Object.Instantiate(poolObjPrefab).GetComponent<IPoolObj>();
                ((MonoBehaviour)poolObj).gameObject.SetActive(false);
                AddPoolObjectToPool(poolObj);
                AvailableObjects.Push(poolObj);
            }
        }

        public void AddPoolObjectToPool(IPoolObj poolObj)
        {
            poolObj.Pool = this;
            AllObjects.Push(poolObj);
        }
        
        public IPoolObj Get()
        {
            if (AvailableObjects.Count == 0)
                CreateBatch(batchAmount);
            IPoolObj obj = AvailableObjects.Pop();
            OnGettingObject(obj);
            return obj;
        }

        public void Return(IPoolObj poolObj)
        {
            AvailableObjects.Push(poolObj);
            OnReturningObject(poolObj);
        }

        public void OnGettingObject(IPoolObj poolObj)
        {
            GameObject obj = ((MonoBehaviour)poolObj).gameObject;
            obj.SetActive(true);
        }

        public void OnReturningObject(IPoolObj poolObj)
        {
            GameObject obj = ((MonoBehaviour)poolObj).gameObject;
            obj.SetActive(false);
        }
    }
}