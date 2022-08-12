using UnityEngine;

public interface IPoolObj
{
    Transform Transform { get; }
    IPool Pool { get; set; }
    void Release();

}
