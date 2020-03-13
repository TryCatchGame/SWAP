using UnityEngine;

using Entity;

public static class ExtensionMethods {
	internal static TileColorSet ToTileColor(this Theme theme) {
		switch(theme) {
			case Theme.Candy:
				// Standard, Inverted, Border Color
				return new TileColorSet(new Color32(196, 69, 105, 255), new Color32(48, 57, 82, 255), Color.grey);
			case Theme.Breeze:
				return new TileColorSet(new Color32(73, 95, 117, 255), new Color32(194, 241, 219, 255), Color.grey);
			case Theme.Coral:
				return new TileColorSet(new Color32(137, 165, 196, 255), new Color32(249, 156, 147, 255), Color.grey);
			case Theme.Hazard:
				return new TileColorSet(new Color32(47, 47, 43, 255), new Color32(255, 113, 41, 255), Color.grey);
			case Theme.Volt:
				return new TileColorSet(new Color32(84, 90, 95, 255), new Color32(251, 235, 88, 255), Color.grey);
			case Theme.Default:
				return new TileColorSet(Color.black, Color.white, Color.grey);
			default:
				return new TileColorSet(Color.black, Color.white, Color.grey);
		}
	}
}
