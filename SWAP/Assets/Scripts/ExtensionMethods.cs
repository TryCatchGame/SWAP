using UnityEngine;

using Entity;

public static class ExtensionMethods {
    internal static TileColorSet ToTileColor(this Theme theme) {
        switch (theme) {
            case Theme.Cherry:
                // Standard, Inverted, Border Color
                return new TileColorSet(Color.black, Color.white, Color.grey);
            default:
                return new TileColorSet(Color.black, Color.white, Color.grey);
        }
    }
}
