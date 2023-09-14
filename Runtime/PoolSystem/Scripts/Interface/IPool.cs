using System.Collections.Generic;

namespace PoolSystem
{
    public interface IPool
    {
        Stack<IPoolObj> AllObjects { get; set; }
        Stack<IPoolObj> AvailableObjects { get; set; }
        void CreateBatch(int amount);
        IPoolObj Get();
        void Return(IPoolObj poolObj);
        void OnGettingObject(IPoolObj obj);
        void OnReturningObject(IPoolObj obj);
    }
}
