using UnityEngine;

namespace Amheklerior.Rewind
{
    public class Bridge : MonoBehaviour
    {
        private Quaternion originalRot;
        public void MoveDown()
        {
            originalRot = transform.rotation;
            transform.rotation = Quaternion.identity;
        }
        public void MoveUp()
        {
            transform.rotation = originalRot;
        }
    }
}