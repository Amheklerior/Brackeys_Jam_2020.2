using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {
    
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour {

        [Header("Events")]
        [SerializeField] private GameEvent _playerInputEnabled;
        [SerializeField] private GameEvent _playerInputDisabled;

        private PlayerInput _playerInput;
        private PlayerMovement _player;

        private void EnablePlayerInput() => _playerInput.EnableInput();
        private void DisablePlayerInput() => _playerInput.DisableInput();

        void Awake() {
            _player = GetComponent<PlayerMovement>();
            _playerInput = new PlayerInput();
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
            if (!_playerInput.IsInputGiven) return;

            switch (_playerInput.Action) {
                case Action.MOVE_UP:
                    if (_player.CanMove(PlayerMovement.Direction.UP)) {
                        _player.Move(PlayerMovement.Direction.UP);
                    }
                    break;

                case Action.MOVE_DOWN:
                    if (_player.CanMove(PlayerMovement.Direction.DOWN)) {
                        _player.Move(PlayerMovement.Direction.DOWN);
                    }
                    break;

                case Action.MOVE_LEFT:
                    if (_player.CanMove(PlayerMovement.Direction.LEFT)) {
                        _player.Move(PlayerMovement.Direction.LEFT);
                    }
                    break;

                case Action.MOVE_RIGHT:
                    if (_player.CanMove(PlayerMovement.Direction.RIGHT)) {
                        _player.Move(PlayerMovement.Direction.RIGHT);
                    }
                    break;

                case Action.REWIND:
                    if (_player.CanRewind) _player.Rewind();
                    break;
            }
        }
        
        #region Imprinting

        private Imprint _imprint = Imprint.NONE;

        private bool HasImprint => _imprint != Imprint.NONE;

        public bool IsMarkedWith(Imprint imprint) => _imprint == imprint;
        
        public void MarkWith(Imprint imprint) {
            if (!HasImprint && !_player.IsRewinding) 
                _imprint = imprint;

            else if (IsMarkedWith(imprint) && _player.IsRewinding)
                _imprint = Imprint.NONE;
            
        }

        #endregion

    }
    
}
