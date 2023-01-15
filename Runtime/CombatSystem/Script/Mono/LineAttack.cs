using System.Collections;
using System.Diagnostics;
using PoolSystem;
using UnityEngine;

namespace CombatSystem
{
    public class LineAttack : MonoBehaviour, ICanAttack
    {
        [SerializeField] Pool bulletPool;
        [SerializeField] LineAttackData data;
        [SerializeField] Transform attackPoint;
        Stopwatch timer = new Stopwatch();
        float lastAttackTime;

        private void Awake()
        {
            timer.Start();
        }

        public void Attack()
        {
            if (data == null) return;
            if (lastAttackTime + data.TimeBetweenAttacksMilliSeconds < timer.ElapsedMilliseconds)
                StartCoroutine(IEAttack());
            else
            {
                UnityEngine.Debug.Log("NotReadyToAttack");
                UnityEngine.Debug.Log("lastAttackTime " + lastAttackTime);
                UnityEngine.Debug.Log("ElapsedMilliseconds " + timer.ElapsedMilliseconds);

            }

        }

        IEnumerator IEAttack()
        {
            lastAttackTime = timer.ElapsedMilliseconds;
            for (int i = 0; i < data.AttackAmount; i++)
            {
                ShotBullet(bulletPool.Get());
                yield return new WaitForSecondsRealtime(data.BulletIntervalMilliSeconds * .001f);
            }
        }

        void ShotBullet(IPoolObj bullet)
        {
            bullet.Transform.position = attackPoint.position;
            bullet.Transform.rotation = attackPoint.rotation;
        }
    }
}