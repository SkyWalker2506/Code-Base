using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : IEvent
{
    public UnityEvent Action { get; set; } = new UnityEvent();
}
