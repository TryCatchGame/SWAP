using UnityEngine;

using MyBox;

using Entity;

namespace Manager {
    public class GameCache : MonoSingleton<GameCache> {

        internal static GridSetup CurrentGridSize { get; set; }

        internal static TileColorSet TileColor { get; private set; }

        protected override void OnAwake() {
        }

        internal static void LoadTileColor(TileColorSet tileColorSet) {
            TileColor = tileColorSet;
        }
    }
}
