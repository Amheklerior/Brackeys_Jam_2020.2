using UnityEngine;
using Amheklerior.Core.EventSystem;
using Amheklerior.Core.Time;

namespace Amheklerior.Rewind {
    
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour {

        [Header("Events:")]
        [SerializeField] private GameEvent _playerInputEnabled;
        [SerializeField] private GameEvent _playerInputDisabled;

        [Space]
        [Header("Dependencies:")]
        [SerializeField] private PlayerState _state;
        
        private PlayerMovement _playerController;
        private PlayerInput _playerInput;

        private Timer _timer;

        private void EnablePlayerInput() => _playerInput.EnableInput();
        private void DisablePlayerInput() => _playerInput.DisableInput();

        void Awake() {
            if (_state == null)
                Debug.LogError("The player state ref is not set.", this);
            _playerController = GetComponent<PlayerMovement>();
            _playerInput = new PlayerInput();
            _timer = new Timer(.5f, () => {
                _state.IsRewinding = false;
                _timer.Stop();
            });
        }

        private void OnEnable() {
            _playerInputEnabled.Subscribe(EnablePlayerInput);
            _playerInputDisabled.Subscribe(DisablePlayerInput);
        }

        private void OnDisable() {
            _playerInputEnabled.Unsubscribe(EnablePlayerInput);
            _playerInputDisabled.Unsubscribe(DisablePlayerInput);
        }

        private void Update() {
            switch (_playerInput.Action) {
                case Action.MOVE_UP:
                    if (_playerController.CanMove(PlayerMovement.Direction.UP)) {
                        _playerController.Move(PlayerMovement.Direction.UP);
                    }
                    break;

                case Action.MOVE_DOWN:
                    if (_playerController.CanMove(PlayerMovement.Direction.DOWN)) {
                        _playerController.Move(PlayerMovement.Direction.DOWN);
                    }
                    break;

                case Action.MOVE_LEFT:
                    if (_playerController.CanMove(PlayerMovement.Direction.LEFT)) {
                        _playerController.Move(PlayerMovement.Direction.LEFT);
                    }
                    break;

                case Action.MOVE_RIGHT:
                    if (_playerController.CanMove(PlayerMovement.Direction.RIGHT)) {
                        _playerController.Move(PlayerMovement.Direction.RIGHT);
                    }
                    break;

                case Action.REWIND:
                    if (_playerController.CanRewind) {
                        if (!_state.IsRewinding) _state.IsRewinding = true;
                        _playerController.Rewind();
                    }
                    break;

                default:
                    if (_state.IsRewinding && !_timer.IsRunning) _timer.Start();
                    _timer.Tick(Time.deltaTime);
                    break;
            }
        }

    }

}
