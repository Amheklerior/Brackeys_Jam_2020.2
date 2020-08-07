using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    public class ModelSwapper : MonoBehaviour {

        [SerializeField] private GameEvent _imprintAcquired;
        [SerializeField] private GameEvent _imprintRemoved;
        [SerializeField] private GameObject _neutreBody;
        [SerializeField] private GameObject _purpleBody;
        [SerializeField] private GameObject _greenBody;
        [SerializeField] private PlayerState _state;

        
        private void OnEnable() {
            _imprintAcquired.Subscribe(ApplyImprintSkin);
            _imprintRemoved.Subscribe(ApplyNeutreSkin);
        }

        private void OnDisable() {
            _imprintAcquired.Unsubscribe(ApplyNeutreSkin);
            _imprintRemoved.Unsubscribe(ApplyImprintSkin);
        }

        private void ApplyImprintSkin() {
            if (_state.IsMarkedWith(Imprint.TRIGGER)) ApplyPurpleSkin();
            else ApplyGreenSkin();
        }
        
        private void ApplyPurpleSkin() {
            _neutreBody.SetActive(false);
            _purpleBody.SetActive(true);
            _greenBody.SetActive(false);
        }

        private void ApplyGreenSkin() {
            _neutreBody.SetActive(false);
            _purpleBody.SetActive(false);
            _greenBody.SetActive(true);
        }

        private void ApplyNeutreSkin() {
            _neutreBody.SetActive(true);
            _purpleBody.SetActive(false);
            _greenBody.SetActive(false);
        }

    }
}
