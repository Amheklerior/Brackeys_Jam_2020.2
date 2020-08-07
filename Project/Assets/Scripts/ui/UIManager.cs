using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class UIManager : MonoBehaviour {

        [SerializeField] private GameObject _cubeTitle;

        [Header("Game events:")]
        [SerializeField] private GameEvent _startNewGame;

        public void PlayButtonClicked()
        {
            //_cubeTitle.SetActive(false);
            _startNewGame.Raise();
        }

    }
}