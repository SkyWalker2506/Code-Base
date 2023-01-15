using System;
using UnityEngine;

namespace CombatSystem
{
    public class Damager : MonoBehaviour, IDamager
    {
        [SerializeField] int damage;
        public int Damage => damage;

        public Action<int> OnDamage { get; set; }

        public void ApplyDamage(IDamagable damagable)
        {
            damagable.ApplyDamage(damage);
            OnDamage?.Invoke(Damage);
        }
    }
}