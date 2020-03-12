using UnityEngine;

namespace Entity {

    [System.Serializable]
    internal readonly struct TileColorSet {
        internal Color StandardColor { get; }

        internal Color InvertedColor { get; }

        internal Color BorderColor { get; }

        internal TileColorSet(Color standard, Color inverted, Color border) =>
            (StandardColor, InvertedColor, BorderColor) = (standard, inverted, border);
    }
}