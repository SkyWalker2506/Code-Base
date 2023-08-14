using UnityEngine;

namespace CodeBase.Core
{
    public interface IHaveTransform
    {
        Transform transform { get; }
    }
    
    public interface IHaveName
    {
        string Name { get; }
    }
}