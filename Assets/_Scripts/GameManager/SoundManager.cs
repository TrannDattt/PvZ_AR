using PlantsZombiesAR.Helpers;
using UnityEngine;

namespace PlantsZombiesAR.GameManager
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioSource _backgroundSound;
        [SerializeField] private AudioSource _sfxSound;

        public float Volume { get; private set; }

        public void ChangeAllVolume(float value)
        {
            Volume = value;
            _backgroundSound.volume = Volume;
            _sfxSound.volume = Volume;
        }

        public void PlayBackground(AudioClip clip)
        {
            _backgroundSound.clip = clip;
            _backgroundSound.Play();
        }

        public void StopBackground() 
        {
            _backgroundSound.Stop();
        }

        public void PlaySFX(AudioClip clip)
        {
            _sfxSound.PlayOneShot(clip);
        }
    }
}
