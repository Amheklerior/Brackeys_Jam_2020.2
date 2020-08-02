using System.Collections;
using UnityEngine;
using Amheklerior.Core.Command;

namespace Amheklerior.Rewind {

    public class PlayerMovement : MonoBehaviour {

        private const int COMPLETE_ROTATION = 90;

        [Header("Dependencies:")]
        [SerializeField] private Transform _center;
        [SerializeField] private Transform _upPivot;
        [SerializeField] private Transform _downPivot;
        [SerializeField] private Transform _rightPivot;
        [SerializeField] private Transform _leftPivot;

        [Space][Header("Settings:")] 
        [SerializeField] private int _deltaRotation = 9;
        [SerializeField] private float _speed = 0.01f;

        
        void Awake() {
            SetupPlayer();
            WireInput();
        }
        
        private void OnEnable() => EnableInput();

        private void OnDisable() => DisableInput();
        
        private void Update() {
            if (!IsInputGiven) return;

            switch (_input) {
                case PlayerInput.UP:
                    GlobalCommandExecutor.Execute(() => MoveUp(), () => MoveDown());
                    break;

                case PlayerInput.DOWN:
                    GlobalCommandExecutor.Execute(() => MoveDown(), () => MoveUp());
                    break;

                case PlayerInput.LEFT:
                    GlobalCommandExecutor.Execute(() => MoveLeft(), () => MoveRight());
                    break;

                case PlayerInput.RIGHT:
                    GlobalCommandExecutor.Execute(() => MoveRight(), () => MoveLeft());
                    break;

                case PlayerInput.REWIND:
                    if (GlobalCommandExecutor.CanUndo()) GlobalCommandExecutor.Undo();
                    break;
            }
        }
        


        #region Input handling

        private enum PlayerInput { NONE, UP, DOWN, LEFT, RIGHT, REWIND }

        private PlayerControls _controls;
        private PlayerInput _input;

        public bool IsInputGiven => _input != PlayerInput.NONE;
        
        void EnableInput() => _controls.Actions.Enable();
        void DisableInput() => _controls.Actions.Disable();
        void ClearInput() => _input = PlayerInput.NONE;

        void WireInput() {
            _controls = new PlayerControls();

            _controls.Actions.MoveUp.performed += ctx => _input = PlayerInput.UP;
            _controls.Actions.MoveUp.canceled += ctx => _input = PlayerInput.NONE;

            _controls.Actions.MoveDown.performed += ctx => _input = PlayerInput.DOWN;
            _controls.Actions.MoveDown.canceled += ctx => _input = PlayerInput.NONE;

            _controls.Actions.MoveLeft.performed += ctx => _input = PlayerInput.LEFT;
            _controls.Actions.MoveLeft.canceled += ctx => _input = PlayerInput.NONE;

            _controls.Actions.MoveRight.performed += ctx => _input = PlayerInput.RIGHT;
            _controls.Actions.MoveRight.canceled += ctx => _input = PlayerInput.NONE;

            _controls.Actions.Rewind.performed += ctx => _input = PlayerInput.REWIND;
            _controls.Actions.Rewind.canceled += ctx => _input = PlayerInput.NONE;
        }

        #endregion


        #region Movement

        private Transform _player;
        private WaitForSeconds _waitForSeconds;
        private bool _isMoving;

        private void SetupPlayer() {
            _player = transform;
            _waitForSeconds = new WaitForSeconds(_speed);
        }


        private void MoveUp() {
            if (!_isMoving) {
                StartCoroutine(FlipUp());
                _isMoving = true;
            }
        }

        private IEnumerator FlipUp() {
            for (int i = 0; i < COMPLETE_ROTATION / _deltaRotation; i++) {
                _player.RotateAround(_upPivot.position, Vector3.right, _deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private void MoveDown() {
            if (!_isMoving) {
                StartCoroutine(FlipDown());
                _isMoving = true;
            }
        }

        private IEnumerator FlipDown() {
            for (int i = 0; i < COMPLETE_ROTATION / _deltaRotation; i++) {
                _player.RotateAround(_downPivot.position, Vector3.left, _deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private void MoveLeft() {
            if (!_isMoving) {
                StartCoroutine(FlipLeft());
                _isMoving = true;
            }
        }

        private IEnumerator FlipLeft() {
            for (int i = 0; i < COMPLETE_ROTATION / _deltaRotation; i++) {
                _player.RotateAround(_leftPivot.position, Vector3.forward, _deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private void MoveRight() {
            if (!_isMoving) {
                StartCoroutine(FlipRight());
                _isMoving = true;
            }
        }

        private IEnumerator FlipRight() {
            for (int i = 0; i < COMPLETE_ROTATION / _deltaRotation; i++) {
                _player.RotateAround(_rightPivot.position, Vector3.back, _deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        #endregion

    }
}