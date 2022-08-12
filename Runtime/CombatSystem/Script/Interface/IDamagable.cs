using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    Action<int> OnDamaged { get; set; }

    void ApplyDamage(int damage);
}