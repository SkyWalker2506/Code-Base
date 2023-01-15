using UnityEngine;

namespace PoolSystem
{
    public class PoolObj : MonoBehaviour, IPoolObj
    {
        public Transform Transform => transform;

        public IPool Pool { get; set; }

        public void Release()
        {
            Pool.Return(this);
        }
    }
}