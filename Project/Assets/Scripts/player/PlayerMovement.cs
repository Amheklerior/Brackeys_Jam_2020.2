using System.Collections;
using UnityEngine;
using Amheklerior.Core.Command;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class PlayerMovement : MonoBehaviour {

        #region Inspector interface 

        [Header("Events:")]
        [SerializeField] private GameEvent _flipCompletedEvent;

        [Space]
        [Header("Dependencies:")]
        [SerializeField] private PlayerState _state;
        [SerializeField] private Transform _colliders;
        [SerializeField] private Transform _pivots;
        [SerializeField] private Transform _upPivot;
        [SerializeField] private Transform _downPivot;
        [SerializeField] private Transform _leftPivot;
        [SerializeField] private Transform _rightPivot;

        [Space]
        [Header("Settings:")]
        [SerializeField] private int _deltaRotation = 5;
        [SerializeField] private float _speed = 0.01f;
        [SerializeField] private float _rewindSpeeupFactor = 3f;

        #endregion

        public enum Direction { UP, DOWN, LEFT, RIGHT }
        
        public bool FreeSlotUp { get; set; } = true;
        public bool FreeSlotDown { get; set; } = true;
        public bool FreeSlotLeft { get; set; } = true;
        public bool FreeSlotRight { get; set; } = true;
        
        public bool CanMove(Direction dir) {
            switch (dir) {
                case Direction.UP:
                    return !_isMoving && FreeSlotUp;

                case Direction.DOWN:
                    return !_isMoving && FreeSlotDown;

                case Direction.LEFT:
                    return !_isMoving && FreeSlotLeft;

                case Direction.RIGHT:
                    return !_isMoving && FreeSlotRight;
            }
            return false;
        }

        public void Move(Direction dir) {
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

        public bool CanRewind => !_isMoving && GlobalCommandExecutor.CanUndo();

        public void Rewind() => GlobalCommandExecutor.Undo();
        
        
        #region Internals

        private const int COMPLETE_ROTATION = 90;

        private Transform _player;
        private WaitForSeconds _waitForSeconds;
        private bool _isMoving;

        private void Awake() {
            if (_state == null)
                Debug.LogError("The player state ref is not set.", this);
            _player = transform;
            _waitForSeconds = new WaitForSeconds(_speed);
        }

        private void MoveUp() => GlobalCommandExecutor.Execute(
            () => StartCoroutine(Flip(Direction.UP)),
            () => StartCoroutine(Flip(Direction.DOWN))
        );

        private void MoveDown() => GlobalCommandExecutor.Execute(
            () => StartCoroutine(Flip(Direction.DOWN)),
            () => StartCoroutine(Flip(Direction.UP))
        );

        private void MoveLeft() => GlobalCommandExecutor.Execute(
            () => StartCoroutine(Flip(Direction.LEFT)),
            () => StartCoroutine(Flip(Direction.RIGHT))
        );

        private void MoveRight() => GlobalCommandExecutor.Execute(
            () => StartCoroutine(Flip(Direction.RIGHT)),
            () => StartCoroutine(Flip(Direction.LEFT))
        );

        private IEnumerator Flip(Direction dir) {
            _isMoving = true;

            Vector3 pivot = Vector3.zero;
            Vector3 direction = Vector3.zero;

            switch (dir) {
                case Direction.UP:
                    pivot = _upPivot.position;
                    direction = Vector3.right;
                    _colliders.Translate(Vector3.forward);
                    _pivots.position = _colliders.position;

                    break;

                case Direction.DOWN:
                    pivot = _downPivot.position;
                    direction = Vector3.left;
                    _colliders.Translate(Vector3.back);
                    _pivots.position = _colliders.position;

                    break;

                case Direction.LEFT:
                    pivot = _leftPivot.position;
                    direction = Vector3.forward;
                    _colliders.Translate(Vector3.left);
                    _pivots.position = _colliders.position;

                    break;

                case Direction.RIGHT:
                    pivot = _rightPivot.position;
                    direction = Vector3.back;
                    _colliders.Translate(Vector3.right);
                    _pivots.position = _colliders.position;

                    break;
            }
            
            var deltaRotation = _state.IsRewinding
                ? _deltaRotation * _rewindSpeeupFactor
                : _deltaRotation;

            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(pivot, direction, deltaRotation);
                yield return _waitForSeconds;
            }

            if (!_state.IsRewinding) 
                _flipCompletedEvent.Raise();
            
            _isMoving = false;
        }

        #endregion

    }
}