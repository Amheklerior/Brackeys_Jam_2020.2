using System.Collections;
using UnityEngine;

namespace Amheklerior.Rewind
{
    public class Bridge : MonoBehaviour
    {
        [Space]
        [Header("Parameters:")]
        [SerializeField] private Transform _pivot;

        public void MoveDown()
        {
            Debug.Log("Bridge DOWN");
            transform.RotateAround(_pivot.position, new Vector3(0,0,1), -90);
        }
        public void MoveUp()
        {
            Debug.Log("Bridge UP");
            transform.RotateAround(_pivot.position, new Vector3(0,0,1), 90);
        }
    }
}