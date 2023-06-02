using SaveSystem;
using UnityEngine;

public class IntTest : MonoBehaviour
{
    [SerializeField] private int _testInt;

    [SerializeField]
    private IntSaveComponent _saveComponent;

    public void SetInt(int value)
    {
        _testInt = value;
        _saveComponent.SetValue(value);
    }
    
    public int GetInt()
    {
        return _testInt;
    }
    
}
