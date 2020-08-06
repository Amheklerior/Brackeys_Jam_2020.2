using UnityEngine;

namespace Amheklerior.Rewind {

    public class MovingPlatform : MonoBehaviour {

        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform _playerPivotGroup;
        [SerializeField] private Transform _playerCheckersGroup;

        [SerializeField] private int _distance;

        public void MoveNorthEast() {
            var destination = Vector3.forward * _distance;
            MakeMove(destination);
        }

        public void MoveNorthWest()
        {
            var destination = Vector3.left * _distance;
            MakeMove(destination);
        }

        public void MoveUp()
        {
            var destination = Vector3.up * _distance;
            MakeMove(destination);
        }

        private void MakeMove(Vector3 destination)
        {
            transform.Translate(destination);
            _playerCheckersGroup.Translate(destination, Space.World);
            _playerPivotGroup.Translate(destination, Space.World);
            _playerBody.Translate(destination, Space.World);
        }

    }
}
