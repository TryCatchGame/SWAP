using UnityEngine;

using MyBox;

namespace Entity {
    public class Tile : MonoBehaviour {

        [SerializeField, MustBeAssigned, AutoProperty]
        private InnerTile inner;

        [SerializeField, MustBeAssigned, AutoProperty]
        private TileBorder border;

        internal void SetColor(Color borderColor, Color innerColor) {
            border.SetColor(borderColor);
            inner.SetColor(innerColor);
        }

        internal float GetLength() {
            return border.GetLength();
        }
    }
}
