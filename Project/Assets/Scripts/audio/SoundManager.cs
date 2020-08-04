using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : GameEventListener {
        
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioEvent _sound;

        public override void OnEventRaised() => _sound.Play(_audioSource);

    }
}