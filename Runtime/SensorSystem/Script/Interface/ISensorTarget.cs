using System;

namespace CodeBase.SensorSystem
{
    public interface ISensorTarget 
    {
        SensorTargetType SensorTargetType { get; }
        Action OnSensed { get; }
    }
}