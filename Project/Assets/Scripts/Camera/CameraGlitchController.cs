using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind
{
    public class CameraGlitchController : MonoBehaviour
    {
        #region Inspector fields

        [Header("Events")]
        [SerializeField] private GameEvent _startRewind;
        [SerializeField] private GameEvent _stopRewind;

        [Space]
        [Header("Dependencies")]
        [SerializeField] private MonoBehaviour glitchScript;

        #endregion

        private void ApplyGlitch() => glitchScript.enabled = true;
        
        private void RemoveGlitch() => glitchScript.enabled = false;
        
        private void OnEnable() {
            _startRewind.Subscribe(ApplyGlitch);
            _stopRewind.Subscribe(RemoveGlitch);
        }

        private void OnDisable() {
            _startRewind.Unsubscribe(ApplyGlitch);
            _stopRewind.Unsubscribe(RemoveGlitch);
        }

    }
}
