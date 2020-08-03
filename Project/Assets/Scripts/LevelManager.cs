using UnityEngine;

namespace Amheklerior.Rewind {
    
    public class LevelManager : MonoBehaviour {

        [SerializeField] private LevelController[] _levels;
        private int _current;

        private void Awake() {
            if (_levels == null || _levels.Length == 0) {
                Debug.LogError("No levels has been set.", this);
            }
        }

        [ContextMenu("Load Next Level")]
        public void LoadNextLevel() {
            _levels[_current].Unload();
            _current++;
            _levels[_current].Load();
        }
        
    }
}