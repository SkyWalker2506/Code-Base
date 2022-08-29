using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBasedMovement2D : MonoBehaviour, ICanMove2D, ICanTurn
{
    [SerializeField] ScriptableFloat turnSpeed;
    [SerializeField] ScriptableFloat moveSpeed;

    public void MoveBackward()
    {
        throw new System.NotImplementedException();
    }

    public void MoveForward()
    {
        if (moveSpeed)
            transform.Translate(Vector3.forward * moveSpeed.Value * Time.deltaTime);
    }

    public void MoveLeft()
    {
        throw new System.NotImplementedException();
    }

    public void MoveRight()
    {
        throw new System.NotImplementedException();
    }

    public void TurnLeft()
    {
        if (turnSpeed)
            transform.Rotate(Vector3.up, turnSpeed.Value * Time.deltaTime);
    }

    public void TurnRight()
    {
        transform.Rotate(Vector3.up, -turnSpeed.Value * Time.deltaTime);
    }
}
