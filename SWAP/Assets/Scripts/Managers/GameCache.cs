using UnityEngine;

using MyBox;

namespace Manager {
    public class GameCache : MonoSingleton<GameCache> {

        #region STRUCT_TileColor
        internal readonly struct TileColorSet {
            internal Color StandardColor { get; }

            internal Color InvertedColor { get; }

            internal Color BorderColor { get; }

            internal TileColorSet(Color standard, Color inverted, Color border) => 
                (StandardColor, InvertedColor, BorderColor) = (standard, inverted, border);
        }
        #endregion

        internal TileColorSet TileColor { get; private set; }

        protected override void OnAwake() {
            GenerateCache();
        }

        // DEBUG!!!!
        private void GenerateCache() {
            TileColor = new TileColorSet(Color.white, Color.black, Color.grey);
        }
    }
}
