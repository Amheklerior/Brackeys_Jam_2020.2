using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudioManager : MonoBehaviour {

        [Header("Events:")]
        [SerializeField] private GameEvent _flip;
        [SerializeField] private GameEvent _startRewind;
        [SerializeField] private GameEvent _stopRewind;

        [Space]
        [Header("Dependencies:")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioEvent _flipSound;
        [SerializeField] private AudioEvent _rewindSound;

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        private void OnEnable() {
            _flip.Subscribe(PlayFlipSound);
            _startRewind.Subscribe(PlayRewindSound);
            _stopRewind.Subscribe(InterruptRewindSound);
        }

        private void OnDisable() {
            _flip.Unsubscribe(PlayFlipSound);
            _startRewind.Unsubscribe(PlayRewindSound);
            _stopRewind.Unsubscribe(InterruptRewindSound);
        }
        
        private void PlayFlipSound() => _flipSound.Play(_audioSource);

        private void PlayRewindSound() {
            _audioSource.loop = true;
            _rewindSound.Play(_audioSource);
        }

        private void InterruptRewindSound() {
            _audioSource.Stop();
            _audioSource.clip = null;
            _audioSource.loop = false;
        }

    }
}
