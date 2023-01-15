using UnityEngine;

namespace CombatSystem
{
    [CreateAssetMenu(menuName = "Data/LineAttackData")]
    public class LineAttackData : ScriptableObject
    {
        public int AttackAmount;
        public int BulletIntervalMilliSeconds;
        public int TimeBetweenAttacksMilliSeconds;
    }
}