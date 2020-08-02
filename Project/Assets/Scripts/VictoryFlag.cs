using UnityEngine;

namespace Amheklerior.Rewind {

    public class VictoryFlag : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {
            Debug.Log("VICTORY!!! :D ");
        }

    }
}
