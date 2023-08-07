using UnityEngine;

namespace InteractionSystem
{
    public interface IAudible
    {
        AudioSource AudioSource {get;}
        AudioClip AudioClip {get;}
        void PlayAudio();
    }
}