using System;
using PoolSystem;
using UnityEngine;

namespace CombatSystem
{
    public class Damager : MonoBehaviour, IDamager, IPoolObj
    {
        [SerializeField] int damage;
        public int Damage => damage;

        public Action<int> OnDamage { get; set; }

        public void ApplyDamage(IDamagable damagable)
        {
            damagable.ApplyDamage(damage);
            OnDamage?.Invoke(Damage);
        }

        public IPool Pool { get; set; }
        public void Release()
        {
            Pool.Return(this);
        }
    }
}