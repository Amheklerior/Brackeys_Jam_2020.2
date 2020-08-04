using UnityEngine;

namespace Amheklerior.Rewind {

    public class CollisionChecker : MonoBehaviour {

        [SerializeField] private PlayerMovement _player;
        [SerializeField] private PlayerMovement.Direction _checkDir;

        private void OnTriggerStay(Collider other) {
            switch (_checkDir) {
                case PlayerMovement.Direction.UP:
                    _player.FreeSlotUp = false;
                    break;

                case PlayerMovement.Direction.DOWN:
                    _player.FreeSlotDown = false;
                    break;

                case PlayerMovement.Direction.LEFT:
                    _player.FreeSlotLeft = false;
                    break;

                case PlayerMovement.Direction.RIGHT:
                    _player.FreeSlotRight = false;
                    break;
            }
        }

        private void OnTriggerExit(Collider other) {
            switch (_checkDir) {
                case PlayerMovement.Direction.UP:
                    _player.FreeSlotUp = true;
                    break;

                case PlayerMovement.Direction.DOWN:
                    _player.FreeSlotDown = true;
                    break;

                case PlayerMovement.Direction.LEFT:
                    _player.FreeSlotLeft = true;
                    break;

                case PlayerMovement.Direction.RIGHT:
                    _player.FreeSlotRight = true;
                    break;
            }
        }

    }
}
