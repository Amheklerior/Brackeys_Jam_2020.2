using UnityEngine;

namespace Amheklerior.Rewind {
    
    public class Imprinter : MonoBehaviour {

        [SerializeField] private Imprint _type;
        [SerializeField] private Player _player;

        private void Awake() {
            if (_type == Imprint.NONE) Debug.LogError("The imprinter cannot be of type NONE.", this); 
            if (_player == null) Debug.LogError("The player ref is not set.", this);
        }

        private void OnTriggerEnter(Collider other) => _player.MarkWith(_type);
        
    }
}
