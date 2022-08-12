﻿using System.Collections.Generic;

public interface IPool
{
    Stack<IPoolObj> AvailableObjects { get; set; }
    public void CreateBatch(int amount);
    IPoolObj Get();
    void Return(IPoolObj poolObj);
    void OnGettingObject(IPoolObj obj);
    void OnReturningObject(IPoolObj obj);
}
