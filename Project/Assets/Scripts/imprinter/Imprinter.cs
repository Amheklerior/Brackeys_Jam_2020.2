using UnityEngine;

namespace Amheklerior.Rewind {
    
    [RequireComponent(typeof(AudioSource))]
    public class Imprinter : MonoBehaviour {
        
        [Header("Dependencies:")]
        [SerializeField] private PlayerState _player;
        [SerializeField] private AudioEvent _giveImprintSound;
        [SerializeField] private AudioEvent _removeImprintSound;
        [SerializeField] private AudioEvent _invalidSound;

        [Space]
        [Header("Settings:")]
        [SerializeField] private Imprint _type;

        private AudioSource _source;

        private void Awake() {
            if (_type == Imprint.NONE) Debug.LogError("The imprinter cannot be of type NONE.", this); 
            if (_player == null) Debug.LogError("The player state ref is not set.", this);
            _source = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other) {
            if (!_player.HasImprint && !_player.IsRewinding) {
                _player.MarkWith(_type);
                _giveImprintSound.Play(_source);

            } else if (_player.IsMarkedWith(_type) && _player.IsRewinding) {
                _player.RemoveMark();
                _removeImprintSound.Play(_source);

            } else {
                _invalidSound.Play(_source);
            }
        }
    }
}
