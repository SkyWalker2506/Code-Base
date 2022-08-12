using UnityEngine;

public class DirectionBasedMovement2D : MonoBehaviour, ICanMove2D
{
    [SerializeField] ScriptableFloat horizontalSpeed;
    [SerializeField] ScriptableFloat verticalSpeed;

    public void MoveBackward()
    {
        if (verticalSpeed)
            transform.Translate(transform.up * -verticalSpeed.Value * Time.deltaTime);
    }

    public void MoveForward()
    {
        if (verticalSpeed)
            transform.Translate(transform.up * verticalSpeed.Value * Time.deltaTime);
    }

    public void MoveLeft()
    {
        if (horizontalSpeed)
            transform.Translate(transform.right * -horizontalSpeed.Value * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (horizontalSpeed)
            transform.Translate(transform.right * horizontalSpeed.Value * Time.deltaTime);
    }

}