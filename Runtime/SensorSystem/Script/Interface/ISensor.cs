using System;
using UnityEngine;

namespace CodeBase.SensorSystem
{
    public interface ISensorLogic 
    {
        float SensorPercentage { get; }
        void Update();
        Action OnSense { get; set; }
    }
}