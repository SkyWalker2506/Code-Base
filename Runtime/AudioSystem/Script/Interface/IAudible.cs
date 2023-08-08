using UnityEngine;

namespace AudioSystem
{
    public interface IAudible
    {
        AudioSource AudioSource {get;}
        AudioClip AudioClip {get;}
        void PlayAudio();
    }
}