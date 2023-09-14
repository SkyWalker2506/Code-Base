using UnityEngine;

namespace PoolSystem
{
    
    public interface IPoolData<out T> where T : MonoBehaviour, IPoolObj 
    {
        T PoolObjPrefab { get; }
        int FirstCreatedAmount{ get; }
        int BatchAmount{ get; }
    }
}