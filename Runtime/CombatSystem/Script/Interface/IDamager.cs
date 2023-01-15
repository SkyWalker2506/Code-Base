using System;

namespace CombatSystem
{
    public interface IDamager
    {
        int Damage { get; }
        Action<int> OnDamage { get; set; }
        void ApplyDamage(IDamagable damagable);

    }
}