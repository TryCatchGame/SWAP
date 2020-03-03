using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyBox;

namespace Entity {
    [RequireComponent(typeof(SpriteRenderer))]
    public class TileBorder : MonoBehaviour {

        [SerializeField, MustBeAssigned, AutoProperty]
        private SpriteRenderer renderer;

        private void Awake() {
            if (renderer == null) {
                renderer = GetComponent<SpriteRenderer>();
            }
        }

        #region Utils

        internal void SetColor(Color color) {
            renderer.color = color;
        }

        internal float GetLength() {
            return renderer.bounds.size.x;
        }

        #endregion
    }
}