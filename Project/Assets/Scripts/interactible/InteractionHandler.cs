using UnityEngine;
using UnityEngine.Events;

namespace Amheklerior.Rewind {
    
    public class InteractionHandler : MonoBehaviour {

        [Header("Dependencies:")]
        [SerializeField] private PlayerState _player;

        [Space]
        [Header("Settings:")]
        [SerializeField] private Imprint _requiredImprint;
        [SerializeField] private UnityEvent _onInteract;

        private bool _alreadyInteracted;

        private void Awake() {
            if (_player == null) Debug.LogError("The player state ref is not set.", this);
            if (_requiredImprint == Imprint.NONE)
                Debug.LogError("The interactible object has to require an imprint other than NONE.", this);
        }

        private void OnTriggerEnter(Collider other) {
            if (!_player.IsMarkedWith(_requiredImprint) || _alreadyInteracted) return;
            _alreadyInteracted = true;
            _onInteract.Invoke();
        }
        
    }
}
