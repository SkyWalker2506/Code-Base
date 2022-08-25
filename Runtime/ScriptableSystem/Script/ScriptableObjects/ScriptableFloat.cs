using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/ScriptableValue/Float")]
public class ScriptableFloat : ScriptableObject
{
    [SerializeField] float value;
    public float Value => value;
    public UnityEvent<float> OnValueChanged;


    private void OnValidate()
    {
        OnValueChanged?.Invoke(value);
    }

    public void UpdateValue(float newValue)
    {
        value = newValue;
        OnValueChanged?.Invoke(value);
    }

}