using UnityEngine;

namespace Amheklerior.Rewind {

    public class MovingPlatform : MonoBehaviour {

        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform _playerPivotGroup;
        [SerializeField] private Transform _playerCheckersGroup;

        [SerializeField] private int _distance;

        public void Move() {
            var destination = Vector3.forward * _distance;
            transform.Translate(destination);
            _playerCheckersGroup.Translate(destination, Space.World);
            _playerPivotGroup.Translate(destination, Space.World);
            _playerBody.Translate(destination, Space.World);
        }

    }
}
