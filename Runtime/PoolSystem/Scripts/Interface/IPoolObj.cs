using UnityEngine;

namespace PoolSystem
{
    public interface IPoolObj
    {
        Transform Transform { get; }
        IPool Pool { get; set; }
        void Release();

    }
}