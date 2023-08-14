using CodeBase.Core;

namespace InteractionSystem
{
    public interface IRequireCollectable :IHaveID
    {
        bool IsCollected { get; }
    }
}