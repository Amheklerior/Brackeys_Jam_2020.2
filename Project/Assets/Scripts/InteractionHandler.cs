using UnityEngine;
using UnityEngine.Events;

namespace Amheklerior.Rewind {
    
    public enum InteractionType { SINGLE, MULTIPLE }

    public class InteractionHandler : MonoBehaviour {

        [Header("Dependencies:")]
        [SerializeField] private Player _player;

        [Space][Header("Interaction Configuration:")]
        [SerializeField] private Imprint _requiredImprint;
        [SerializeField] private InteractionType _interactionType;
        [SerializeField] private UnityEvent _onInteract;

        private bool _hasAlreadyInteracted;

        private void Awake() {
            if (_requiredImprint == Imprint.NONE)
                Debug.LogError("The interactible object has to require an imprint other than NONE.", this);
            if (_player == null) Debug.LogError("The player ref is not set.", this);
        }

        private void OnTriggerEnter(Collider other) {
            if (_interactionType == InteractionType.SINGLE && _hasAlreadyInteracted)
                return;

            if (_player.IsMarkedWith(_requiredImprint)) {
                _onInteract?.Invoke();
                _hasAlreadyInteracted = true;
            }
        }
        
    }
}
