using UnityEngine;

namespace Amheklerior.Rewind {
    public class Bridge : MonoBehaviour {
        
        [SerializeField] private Transform _pivot;

        public void MoveDown() => transform.RotateAround(_pivot.position, new Vector3(0,0,1), -90);
        
        public void MoveUp() => transform.RotateAround(_pivot.position, new Vector3(0,0,1), 90);
        
    }
}