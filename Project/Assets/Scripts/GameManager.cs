using UnityEngine;
using Amheklerior.Core.EventSystem;
using Amheklerior.Core.Command;

namespace Amheklerior.Rewind {

    public class GameManager : MonoBehaviour {

        #region Inspector interface 

        [Header("Game events:")]
        [SerializeField] private GameEvent _newGameEvent;
        [SerializeField] private GameEvent _levelCompleted;
        [SerializeField] private GameEvent _playerInputEnabled;
        [SerializeField] private GameEvent _playerInputDisabled;

        [Space]
        [SerializeField] private GameObject[] _levels;

        [Space]
        [Header("UI refs:")]
        [SerializeField] private GameObject _mainMenuScreen;
        [SerializeField] private GameObject _victoryScreen;

        #endregion

        private int _currentLevel;
        
        private bool IsOnLastLevel => _currentLevel == _levels.Length - 1;

        private void ShowMainMenu() => _mainMenuScreen.SetActive(true);
        private void HideMainMenu() => _mainMenuScreen.SetActive(false);
        private void ShowVictoryScreen() => _victoryScreen.SetActive(true);
        private void HideVictoryScreen() => _victoryScreen.SetActive(false);

        private void LoadLevel(int index) => _levels[index].SetActive(true);
        private void UnloadLevel(int index) => _levels[index].SetActive(false);
        

        private void OnEnable() {
            _newGameEvent.Subscribe(StartNewGame);
            _levelCompleted.Subscribe(OnLevelCompleted);
        }

        private void OnDisable() {
            _newGameEvent.Unsubscribe(StartNewGame);
            _levelCompleted.Unsubscribe(OnLevelCompleted);
        }
        
        private void StartNewGame() {
            HideMainMenu();
            LoadLevel(_currentLevel);
            _playerInputEnabled.Raise();
        }

        private void OnLevelCompleted() {
            if (IsOnLastLevel) EndGame();
            else GoToNextLevel();
        }

        private void GoToNextLevel() {
            _playerInputDisabled.Raise();
            UnloadLevel(_currentLevel);
            _currentLevel++;
            LoadLevel(_currentLevel);
            _playerInputEnabled.Raise();
        }
        
        private void EndGame() {
            _playerInputDisabled.Raise();
            UnloadLevel(_currentLevel);
            ShowVictoryScreen();
        }

        private void RestartCurrentLevel() {
            _playerInputDisabled.Raise();
            UnloadLevel(_currentLevel);
            LoadLevel(_currentLevel);
            _playerInputEnabled.Raise();
        }

    }
}