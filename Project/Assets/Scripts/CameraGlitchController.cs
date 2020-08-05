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
        [Space]
        [SerializeField] private GameEvent _startRewind;
        [SerializeField] private GameEvent _stopRewind;

        [Header("Dependencies")]
        [Space]
        [SerializeField] private MonoBehaviour glitchScript;
        #endregion

        private void StartRewind() 
        { 
            Debug.Log("Start REWIND");
            glitchScript.enabled = true;
        }
        private void StopRewind() 
        { 
            Debug.Log("End REWIND"); 
            glitchScript.enabled = false;
        }
        private void OnEnable()
        {
            _startRewind.Subscribe(StartRewind);
            _stopRewind.Subscribe(StopRewind);
        }

        private void OnDisable()
        {
            _startRewind.Unsubscribe(StartRewind);
            _stopRewind.Unsubscribe(StopRewind);
        }

    }
}