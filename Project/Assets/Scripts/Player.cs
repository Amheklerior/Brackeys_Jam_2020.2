using System;
using System.Collections;
using UnityEngine;
using Amheklerior.Core.Command;

namespace Amheklerior.Rewind {
    
    public class Player : MonoBehaviour {

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
        [SerializeField] private float _rewindSpeeupFactor = 2.5f;

        private bool _isRewinding;


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
                    Move(Direction.UP);
                    break;

                case PlayerInput.DOWN:
                    Move(Direction.DOWN);
                    break;

                case PlayerInput.LEFT:
                    Move(Direction.LEFT);
                    break;

                case PlayerInput.RIGHT:
                    Move(Direction.RIGHT);
                    break;

                case PlayerInput.REWIND:
                    if (!_isMoving && GlobalCommandExecutor.CanUndo()) {
                        GlobalCommandExecutor.Undo();
                        _isRewinding = true;
                    }
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

        private enum Direction { UP, DOWN, LEFT, RIGHT }

        private Transform _player;
        private WaitForSeconds _waitForSeconds;
        private bool _isMoving;

        private void SetupPlayer() {
            _player = transform;
            _waitForSeconds = new WaitForSeconds(_speed);
        }

        private void Move(Direction dir) {
            if (_isMoving) return;

            _isRewinding = false;

            switch (dir) {
                case Direction.UP:
                    MoveUp();
                    break;

                case Direction.DOWN:
                    MoveDown();
                    break;

                case Direction.LEFT:
                    MoveLeft();
                    break;

                case Direction.RIGHT:
                    MoveRight();
                    break;
            }
        }
        
        private void MoveUp() => GlobalCommandExecutor.Execute(
            () => FlipCube(Direction.UP),
            () => FlipCube(Direction.DOWN)
        );

        private void MoveDown() => GlobalCommandExecutor.Execute(
            () => FlipCube(Direction.DOWN),
            () => FlipCube(Direction.UP)
        );

        private void MoveLeft() => GlobalCommandExecutor.Execute(
            () => FlipCube(Direction.LEFT),
            () => FlipCube(Direction.RIGHT)
        );

        private void MoveRight() => GlobalCommandExecutor.Execute(
            () => FlipCube(Direction.RIGHT),
            () => FlipCube(Direction.LEFT)
        );

        #region Animation

        private void FlipCube(Direction dir) {
            switch (dir) {
                case Direction.UP:
                    StartCoroutine(FlipUp());
                    break;

                case Direction.DOWN:
                    StartCoroutine(FlipDown());
                    break;

                case Direction.LEFT:
                    StartCoroutine(FlipLeft());
                    break;

                case Direction.RIGHT:
                    StartCoroutine(FlipRight());
                    break;
            }
        }

        // TODO -- Refactor the common code in one coroutine function?!
        
        private IEnumerator FlipUp() {
            _isMoving = true;
            var deltaRotation = _isRewinding ? _deltaRotation * _rewindSpeeupFactor : _deltaRotation;
            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(_upPivot.position, Vector3.right, deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private IEnumerator FlipDown() {
            _isMoving = true;
            var deltaRotation = _isRewinding ? _deltaRotation * _rewindSpeeupFactor : _deltaRotation;
            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(_downPivot.position, Vector3.left, deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private IEnumerator FlipLeft() {
            _isMoving = true;
            var deltaRotation = _isRewinding ? _deltaRotation * _rewindSpeeupFactor : _deltaRotation;
            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(_leftPivot.position, Vector3.forward, deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        private IEnumerator FlipRight() {
            _isMoving = true;
            var deltaRotation = _isRewinding ? _deltaRotation * _rewindSpeeupFactor : _deltaRotation;
            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(_rightPivot.position, Vector3.back, deltaRotation);
                yield return _waitForSeconds;
            }
            _center.position = _player.position;
            _isMoving = false;
        }

        #endregion

        #endregion


        #region Imprinting

        [SerializeField] private Imprint _imprint = Imprint.NONE;

        private bool HasImprint => _imprint != Imprint.NONE;

        public bool IsMarkedWith(Imprint imprint) => _imprint == imprint;
        
        public void MarkWith(Imprint imprint) {
            if (!HasImprint && !_isRewinding) 
                _imprint = imprint;

            else if (IsMarkedWith(imprint) && _isRewinding)
                _imprint = Imprint.NONE;
            
        }

        #endregion

    }
}
