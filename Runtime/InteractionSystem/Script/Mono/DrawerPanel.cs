using UnityEngine;

namespace InteractionSystem
{
    public class DrawerPanel : OpenableMovingBase, IAudible
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        public AudioClip AudioClip { get; private set; }
        [SerializeField] private AudioClip openClip; 
        [SerializeField] private AudioClip closeClip;

        public override void Open()
        {
            AudioClip = openClip;
            PlayAudio();
            base.Open();
        }

        public override void Close()
        {
            AudioClip = closeClip;
            PlayAudio();
            base.Close();
        }

        public void PlayAudio()
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}