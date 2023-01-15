using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSystem
{
    public class Damagable : MonoBehaviour, IDamagable
    {
        public static Dictionary<GameObject, Damagable> Damagables = new Dictionary<GameObject, Damagable>();
        public Action<int> OnDamaged { get; set; }

        private void Awake()
        {
            Damagables.Add(gameObject, this);
        }

        public void ApplyDamage(int damage)
        {
            OnDamaged?.Invoke(damage);
        }
    }
}