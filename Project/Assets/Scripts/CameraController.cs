using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind
{
    public class CameraController : MonoBehaviour
    {
        #region Inspector fields
        [Header("Events")]
        [Space]
        [SerializeField] private GameEvent _camShake;
        [SerializeField] private GameEvent _rewindEnabled;
        [SerializeField] private GameEvent _rewindDisabled;

        [Header("Parameters")]
        [Space]
        [SerializeField] private bool _cameraShake;
        [SerializeField] private float _shakeDuration = 0.3f;
        [SerializeField] private float _shakeAmplitude = 1f;
        [SerializeField] private float _shakeFrequency = 1f;
        #endregion

        #region Private fields
        private Cinemachine.CinemachineBasicMultiChannelPerlin vcamNoise;
        private float shakeElapsedTime = 0f;
        private WaitForSeconds _waitForSeconds;
        #endregion

        private void EnableRewind() { Debug.Log("Start REWIND"); }
        private void DisableRewind() { Debug.Log("End REWIND"); }

        private void OnEnable()
        {
            _camShake.Subscribe(PlayCameraShake);
            _rewindEnabled.Subscribe(EnableRewind);
            _rewindDisabled.Subscribe(DisableRewind);
        }

        private void OnDisable()
        {
            _camShake.Unsubscribe(PlayCameraShake);
            _rewindEnabled.Unsubscribe(EnableRewind);
            _rewindDisabled.Unsubscribe(DisableRewind);
        }

        private void Awake()
        {
            vcamNoise = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }

        public void PlayCameraShake()
        {
            if (_cameraShake)
            {
                Debug.Log("BEFORE start shake");
                shakeElapsedTime = _shakeDuration;
                StartCoroutine(Shaking());
            }
        }

        private IEnumerator Shaking()
        {
            if (vcamNoise != null)
            {
                while (shakeElapsedTime > 0)
                {
                    Debug.Log("Shaking");
                    vcamNoise.m_AmplitudeGain = _shakeAmplitude;
                    vcamNoise.m_FrequencyGain = _shakeFrequency;

                    shakeElapsedTime -= Time.deltaTime;
                    yield return _waitForSeconds;
                }
                Debug.Log("END Shaking");
                vcamNoise.m_AmplitudeGain = 0;
                shakeElapsedTime = 0;
            }
        }
    }

}