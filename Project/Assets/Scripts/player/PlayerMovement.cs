using System.Collections;
using UnityEngine;
using Amheklerior.Core.Command;

namespace Amheklerior.Rewind {

    public class PlayerMovement : MonoBehaviour {

        #region Inspector interface 

        [Header("Dependencies:")]
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

        public bool IsRewinding { get; private set; }

        public bool CanMove(Direction dir) {
            switch (dir) {
                case Direction.UP:
                    return !_isMoving && FreeSlotUp;

                case Direction.DOWN:
                    return !_isMoving && FreeSlotDown;

                case Direction.LEFT:
                    return !_isMoving && FreeSlotLeft;

                default:
                    return !_isMoving && FreeSlotRight;
            }
        }

        public void Move(Direction dir) {
            IsRewinding = false;
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

        public void Rewind() {
            GlobalCommandExecutor.Undo();
            IsRewinding = true;
        }


        #region Internals

        private const int COMPLETE_ROTATION = 90;

        private Transform _player;
        private WaitForSeconds _waitForSeconds;
        private bool _isMoving;

        private void Awake() {
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
                    break;

                case Direction.DOWN:
                    pivot = _downPivot.position;
                    direction = Vector3.left;
                    break;

                case Direction.LEFT:
                    pivot = _leftPivot.position;
                    direction = Vector3.forward;
                    break;

                case Direction.RIGHT:
                    pivot = _rightPivot.position;
                    direction = Vector3.back;
                    break;
            }

            var deltaRotation = IsRewinding
                ? _deltaRotation * _rewindSpeeupFactor
                : _deltaRotation;

            for (int i = 0; i < COMPLETE_ROTATION / deltaRotation; i++) {
                _player.RotateAround(pivot, direction, deltaRotation);
                yield return _waitForSeconds;
            }

            _colliders.position = _player.position;
            _pivots.position = _player.position;
            _isMoving = false;
        }

        #endregion

    }
}