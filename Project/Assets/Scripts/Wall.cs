using UnityEngine;

namespace Amheklerior.Rewind {

    public class Wall : MonoBehaviour {

        public void MoveDown() {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x, scale.y/3, scale.z); //transform.Translate(Vector3.down);
        }
    }
}
