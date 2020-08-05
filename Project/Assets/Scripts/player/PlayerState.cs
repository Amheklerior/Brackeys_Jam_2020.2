﻿using UnityEngine;
using Amheklerior.Core.EventSystem;

namespace Amheklerior.Rewind {

    [CreateAssetMenu(menuName = "Player State")]
    public class PlayerState : ScriptableObject {

        [SerializeField] private GameEvent _startRewinding;
        [SerializeField] private GameEvent _stopRewinding;

        private bool _rewind;
        private Imprint _imprint = Imprint.NONE;

        private void OnEnable() => ClearMark();
        
        public bool IsRewinding {
            get => _rewind;
            set {
                _rewind = value;
                if (_rewind) _startRewinding.Raise();
                else _stopRewinding.Raise();
            }
        }

        public bool HasImprint => _imprint != Imprint.NONE;

        public bool IsMarkedWith(Imprint imprint) => _imprint == imprint;
        
        public void MarkWith(Imprint imprint) => _imprint = imprint;

        public void ClearMark() => _imprint = Imprint.NONE;
        
    }
}
