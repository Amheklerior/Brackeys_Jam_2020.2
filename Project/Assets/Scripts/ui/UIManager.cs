using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class UIManager : MonoBehaviour {

        [Header("Game events:")]
        [SerializeField] private GameEvent _startNewGame;

        [Header("UI refs:")]
        [SerializeField] private GameObject _mainmenuCanvas;
        [SerializeField] private GameObject _controlsCanvas;

        public void PlayButtonClicked()
        {
            _startNewGame.Raise();
        }

        public void ControlsButtonClicked()
        {
            _mainmenuCanvas.SetActive(false);
            _controlsCanvas.SetActive(true);
        }

        public void BackBtnControlsClicked()
        {
            _controlsCanvas.SetActive(false);
            _mainmenuCanvas.SetActive(true);
        }
    }
}