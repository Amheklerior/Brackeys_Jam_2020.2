using UnityEngine;
using UnityEngine.Events;

namespace Amheklerior.Rewind {
    
    public class InteractionHandler : MonoBehaviour {

        [Header("Dependencies:")]
        [SerializeField] private PlayerState _player;
        [SerializeField] private AudioEvent _interactSound;

        [Space]
        [Header("Settings:")]
        [SerializeField] private Imprint _requiredImprint;
        [SerializeField] private UnityEvent _onInteract;

        private bool _alreadyInteracted;
        private AudioSource _source;

        private void Awake() {
            if (_player == null) Debug.LogError("The player state ref is not set.", this);
            if (_requiredImprint == Imprint.NONE)
                Debug.LogError("The interactible object has to require an imprint other than NONE.", this);
            _source = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other) {
            if (!_player.IsMarkedWith(_requiredImprint) || _alreadyInteracted) return;
            _alreadyInteracted = true;
            _interactSound.Play(_source);
            _onInteract.Invoke();
        }
        
    }
}
