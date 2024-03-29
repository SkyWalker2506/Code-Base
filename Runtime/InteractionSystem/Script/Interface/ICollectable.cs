﻿using System;
using CodeBase.Core;

namespace InteractionSystem
{
    public interface ICollectable : IHaveName, IHaveID
    {
        Action OnCollected{ get; set; }
        void Collect();
    }
}