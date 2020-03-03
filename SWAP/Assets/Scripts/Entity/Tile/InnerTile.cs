using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyBox;

namespace Entity {
    [RequireComponent(typeof(SpriteRenderer))]
    public class InnerTile : MonoBehaviour {

        [SerializeField, MustBeAssigned, AutoProperty]
        private SpriteRenderer renderer;

        private void Awake() {
            if (renderer == null) {
                renderer = GetComponent<SpriteRenderer>();
            }
        }

        internal void SetColor(Color color) {
            renderer.color = color;
        }
    }
}
