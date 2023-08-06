using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConditionBaseStateSystem;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "StateSystem/StateCondition/Create CheckWarScene", fileName = "CheckWarScene", order = 0)]
public class CheckWarSceneCondition : ScriptableStateCondition
{
    public override bool IsConditionMet()
    {
        Debug.Log("??????");
        return SceneManager.GetActiveScene().name == "War Scene";
    }
}
