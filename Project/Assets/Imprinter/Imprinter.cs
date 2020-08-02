using UnityEngine;

namespace Amheklerior.Rewind {

    public enum Imprint { NONE, TRIGGER, JUMPER }

    public class Imprinter : MonoBehaviour {

        [SerializeField] private Imprint _type;

        private void OnTriggerEnter(Collider other) => other.GetComponent<PlayerMovement>().MarkWith(_type);
        
    }

}