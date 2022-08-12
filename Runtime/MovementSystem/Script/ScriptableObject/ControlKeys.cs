using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/ControlKeys")]
public class ControlKeys : ScriptableObject
{
    public KeyCode TurnLeftKey;
    public KeyCode TurnRightKey;
    public KeyCode MoveForwardKey;
    public KeyCode ShotKey;
}
