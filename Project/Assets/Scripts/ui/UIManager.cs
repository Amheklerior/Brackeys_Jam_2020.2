using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class UIManager : MonoBehaviour {

        [Header("Game events:")]
        [SerializeField] private GameEvent _startNewGame;
        
        public void PlayButtonClicked() => _startNewGame.Raise();

    }
}