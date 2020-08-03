using UnityEngine;

namespace Amheklerior.Rewind {

    public class LevelController : MonoBehaviour {

        [SerializeField] private Transform _initialPlayerPosition;

        public void Load() {
            gameObject.SetActive(true);
        }

        public void Unload() {
            gameObject.SetActive(false);
        }

    }
}
