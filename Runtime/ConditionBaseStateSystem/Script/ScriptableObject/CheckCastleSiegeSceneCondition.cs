using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConditionBaseStateSystem;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "StateSystem/StateCondition/Create CheckCastleWar", fileName = "CheckCastleWar", order = 0)]
public class CheckCastleSiegeSceneCondition : ScriptableStateCondition
{
    public override bool IsConditionMet()
    {
        return SceneManager.GetActiveScene().name == "Castle Scene";
    }
}
