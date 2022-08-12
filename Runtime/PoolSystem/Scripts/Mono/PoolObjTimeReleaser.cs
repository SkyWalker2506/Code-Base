using UnityEngine;

public class PoolObjTimeReleaser : MonoBehaviour, IPoolObj
{
    public Transform Transform => transform;

    public IPool Pool { get; set; }
    [SerializeField] ScriptableFloat releaseTime;

    private void OnEnable()
    {
        if (releaseTime)
            Invoke(nameof(Release), releaseTime.Value);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void Release()
    {
        Pool.Return(this);
    }    
}