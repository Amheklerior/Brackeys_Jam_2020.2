using UnityEngine;

namespace Amheklerior.Rewind {
    
    public class Imprinter : MonoBehaviour {
        
        [Header("Dependencies:")]
        [SerializeField] private PlayerState _player;

        [Space]
        [Header("Settings:")]
        [SerializeField] private Imprint _type;

        private void Awake() {
            if (_type == Imprint.NONE) Debug.LogError("The imprinter cannot be of type NONE.", this); 
            if (_player == null) Debug.LogError("The player state ref is not set.", this);
        }

        private void OnTriggerEnter(Collider other) {
            if (!_player.HasImprint && !_player.IsRewinding)
                _player.MarkWith(_type);

            else if (_player.IsMarkedWith(_type) && _player.IsRewinding)
                _player.RemoveMark();
        }
    }
}
