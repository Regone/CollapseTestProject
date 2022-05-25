using System;
using DG.Tweening;
using UnityEngine;

namespace Collapse.Blocks {
    public class Bomb : Block {
        [SerializeField]
        private Transform Sprite;

        [SerializeField]
        private Vector3 ShakeStrength;

        [SerializeField]
        private int ShakeVibrato;

        [SerializeField]
        private float ShakeDuration;

        private Vector3 origin;

        private void Awake() {
            origin = Sprite.localPosition;
        }

        protected override void OnMouseUp() {
            Shake();
        }
        
        /**
         * Convenience for shake animation with callback in the end
         */
        private void Shake(Action onComplete = null) {
            Sprite.DOKill();
            Sprite.localPosition = origin;
            Sprite.DOShakePosition(ShakeDuration, ShakeStrength, ShakeVibrato, fadeOut: false).onComplete += () => {
                onComplete?.Invoke();
            };
        }

        public override void Triger(float delay) {
            if (Triggered) return;
            Triggered = true;
            BoardManager.Instance.TriggerBomb(this);
        }
    }
}