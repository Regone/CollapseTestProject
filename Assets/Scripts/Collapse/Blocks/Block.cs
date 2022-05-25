using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collapse.Blocks {
    public abstract class Block : MonoBehaviour {
        public BlockType Type;
        public Vector2Int GridPosition;

        protected bool Triggered;
        
        private void Start() {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, .2f).SetDelay(Random.value * .3f);
        }

        private void OnMouseEnter() {
            if (Triggered) return;
            transform.DOKill();
            transform.DOScale(Vector3.one * 1.2f, .1f).SetEase(Ease.OutQuad);
        }

        private void OnMouseExit() {
            if (Triggered) return;
            transform.DOKill();
            transform.DOScale(Vector3.one, .1f).SetEase(Ease.OutQuad);
        }

        protected virtual void OnMouseUp() {
            if (Triggered) return;
            BoardManager.Instance.TriggerMatch(this);
        }

        /**
         * Trigger the block, notify the board and destroy the GameObject
         */
        public virtual void Triger(float delay) {
            if (Triggered) return;
            Triggered = true;
            
            BoardManager.Instance.ClearBlockFromGrid(this);
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}