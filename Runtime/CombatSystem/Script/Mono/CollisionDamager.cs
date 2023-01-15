using UnityEngine;

namespace CombatSystem
{
    public class CollisionDamager : Damager
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (Damagable.Damagables.ContainsKey(collision.gameObject))
                ApplyDamage(Damagable.Damagables[collision.gameObject]);
        }
    }
}