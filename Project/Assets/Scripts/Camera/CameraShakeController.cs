using System.Collections;
using Cinemachine;
using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class CameraShakeController : MonoBehaviour {

        #region Inspector fields

        [Header("Events")]
        [SerializeField] private GameEvent _levelCompleted;
        [SerializeField] private GameEvent _ImprintTaken;
        [SerializeField] private GameEvent _imprintRemoved;

        [Space]
        [Header("Parameters")]
        [SerializeField] private bool _cameraShake;
        [SerializeField] private float _shakeDuration = 0.3f;
        [SerializeField] private float _shakeAmplitude = 1f;
        [SerializeField] private float _shakeFrequency = 1f;

        #endregion

        private void OnEnable() {
            _levelCompleted.Subscribe(PlayCameraShake);
            _ImprintTaken.Subscribe(PlayCameraShake);
            _imprintRemoved.Subscribe(PlayCameraShake);
        }

        private void OnDisable() {
            _levelCompleted.Unsubscribe(PlayCameraShake);
            _ImprintTaken.Unsubscribe(PlayCameraShake);
            _imprintRemoved.Unsubscribe(PlayCameraShake);
        }

        private void PlayCameraShake() {
            if (!_cameraShake) return;
            shakeElapsedTime = _shakeDuration;
            StartCoroutine(Shaking());
        }

        #region Internals

        private CinemachineBasicMultiChannelPerlin vcamNoise;
        private float shakeElapsedTime = 0f;
        private WaitForSeconds _waitForSeconds;


        private void Awake() {
            vcamNoise = GetComponent<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private IEnumerator Shaking() {
            if (vcamNoise != null) {
                while (shakeElapsedTime > 0) {
                    vcamNoise.m_AmplitudeGain = _shakeAmplitude;
                    vcamNoise.m_FrequencyGain = _shakeFrequency;

                    shakeElapsedTime -= Time.deltaTime;
                    yield return _waitForSeconds;
                }
                vcamNoise.m_AmplitudeGain = 0;
                shakeElapsedTime = 0;
            }
        }

        #endregion

    }
}