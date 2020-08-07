using UnityEngine;

namespace Amheklerior.Rewind {

    public class MovingPlatform : MonoBehaviour {

        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform _playerPivotGroup;
        [SerializeField] private Transform _playerCheckersGroup;

        [SerializeField] private int _distance;

        [ContextMenu("Move North East")]
        public void MoveNorthEast() => MakeMove(Vector3.forward * _distance);
        
        [ContextMenu("Move North West")]
        public void MoveNorthWest() => MakeMove(Vector3.left * _distance);
        
        public void MoveUp() => MakeMove(Vector3.up * _distance);
        
        private void MakeMove(Vector3 destination) {
            transform.Translate(destination);
            _playerCheckersGroup.Translate(destination, Space.World);
            _playerPivotGroup.Translate(destination, Space.World);
            _playerBody.Translate(destination, Space.World);
        }

    }
}
