using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    public interface IDialogueLine
    {
        IDialogueOwner Owner{ get; }
        string Line{ get; }
        AudioClip AudioClip{ get; } 
        UnityEvent OnLineStarted{ get; }
        UnityEvent OnLineEnded{ get; }
    }
}