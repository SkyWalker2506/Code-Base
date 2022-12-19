using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public Vector3 followOffset;  

    void Update()
    {
        Vector3 targetPosition = target.position + followOffset;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}