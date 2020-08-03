using System.Collections;
using UnityEngine;

namespace Amheklerior.Rewind {

    public class CollisionChecker : MonoBehaviour {

        [SerializeField] private Player _player;
        [SerializeField] private Player.Direction _checkDir;

        private void OnTriggerEnter(Collider other) {
            switch(_checkDir) {
                case Player.Direction.UP:
                    _player.CanMoveUp = false;
                    break;

                case Player.Direction.DOWN:
                    _player.CanMoveDown = false;
                    break;

                case Player.Direction.LEFT:
                    _player.CanMoveLeft = false;
                    break;

                case Player.Direction.RIGHT:
                    _player.CanMoveRight = false;
                    break;
            }
        }

        private void OnTriggerExit(Collider other) {
            switch (_checkDir) {
                case Player.Direction.UP:
                    _player.CanMoveUp = true;
                    break;

                case Player.Direction.DOWN:
                    _player.CanMoveDown = true;
                    break;

                case Player.Direction.LEFT:
                    _player.CanMoveLeft = true;
                    break;

                case Player.Direction.RIGHT:
                    _player.CanMoveRight = true;
                    break;
            }
        }

    }
}
