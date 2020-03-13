using UnityEngine;

using MyBox;
using Manager;

namespace Entity {
	[RequireComponent(typeof(TappableObject))]
	public class Tile : MonoBehaviour {

		[SerializeField, MustBeAssigned, AutoProperty]
		private InnerTile inner;

		[SerializeField, MustBeAssigned, AutoProperty]
		private TileBorder border;

		[SerializeField, MustBeAssigned, AutoProperty]
		private TappableObject selfTappable;

		public bool IsInverted { get; private set; }

		public GridPoint Point { get; private set; }

		private void Awake() {
			if(selfTappable == null) {
				selfTappable = GetComponent<TappableObject>();
			}

			selfTappable.onTapped = FlipSurroundingTiles;
			// DEBUG!!!!
			IsInverted = true;
		}

		internal void Initalize(GridPoint point) {
			Point = point;
		}

		private void FlipSurroundingTiles() {
			TileGrid gridInstance = TileGrid.Instance;

			// TODO: Refactor

			if(gridInstance.TryGetTile(Point + (GridPoint)Vector2Int.left, out Tile leftTile)) {
				leftTile.FlipColor();
			}

			if(gridInstance.TryGetTile(Point + (GridPoint)Vector2Int.right, out Tile rightTile)) {
				rightTile.FlipColor();
			}

			if(gridInstance.TryGetTile(Point + (GridPoint)Vector2Int.up, out Tile upTile)) {
				upTile.FlipColor();
			}

			if(gridInstance.TryGetTile(Point + (GridPoint)Vector2Int.down, out Tile downTile)) {
				downTile.FlipColor();
			}
		}

		#region Utils
		internal void SetColor(Color borderColor, Color innerColor) {
			border.SetColor(borderColor);
			inner.SetColor(innerColor);
		}

		internal float GetLength() {
			return border.GetLength();
		}

		private void FlipColor() {
			Color innerColor;

			if(IsInverted) {
				innerColor = GameCache.TileColor.StandardColor;
			} else {
				innerColor = GameCache.TileColor.InvertedColor;
			}

			IsInverted = !IsInverted;
			SetColor(GameCache.TileColor.BorderColor, innerColor);
		}
		#endregion
	}
}
