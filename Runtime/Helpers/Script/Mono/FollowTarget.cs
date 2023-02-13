using UnityEngine;
using UnityEngine.Serialization;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private bool _followX; 
    [SerializeField] private bool _followY; 
    [SerializeField] private bool _followZ; 
    [FormerlySerializedAs("followOffset")] public Vector3 _followOffset;  
    
    void Update()
    {
        Vector3 targetPosition = _followOffset;
        if (_followX)
        {
            targetPosition.x += target.position.x;
        }
        if (_followY)
        {
            targetPosition.y += target.position.y;
        }
        if (_followZ)
        {
            targetPosition.z += target.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}