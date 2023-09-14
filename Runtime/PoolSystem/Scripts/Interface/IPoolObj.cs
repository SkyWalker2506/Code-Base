using UnityEngine;

namespace PoolSystem
{
    public interface IPoolObj
    {
        Transform transform { get; }
        IPool Pool { get; set; }
        void Release();
    }
}