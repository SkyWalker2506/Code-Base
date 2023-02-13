using System;

namespace CodeBase.SensorSystem
{
    public interface ISensor 
    {
        SensorTargetType SensorTargetType { get; }
        void CheckTarget();
        Action OnSense { get; set; }
    }
}