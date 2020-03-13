using System;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;

namespace Manager {
	public class MenuManager : MonoBehaviour {

		[SerializeField, Tooltip("Reference to settings canvas")]
		private GameObject settingsCanvas;

		[SerializeField, Tooltip("Reference to theme select scroll rect")]
		private SimpleScrollSnap scrollSnap;

		private void Awake() {
			GameCache.CurrentGridSize = GridSetup.Five_By_Five;

			GameCache.LoadTileColor(new Entity.TileColorSet(Color.white, Color.black, Color.grey));
		}

		public void UpdateTheme() {
			int themeIndex = scrollSnap.TargetPanel;
			GameCache.LoadTileColor(((Theme)themeIndex).ToTileColor());
		}

		public void ToggleSettingPage(bool state) {
			settingsCanvas.SetActive(state);
		}

		public void IncreaseGridSize() {
			ShiftGridSize(1);
		}

		public void DecreaseGridSize() {
			ShiftGridSize(-1);
		}

		private void ShiftGridSize(int count) {
			int nextGridSize = (int)GameCache.CurrentGridSize + count;

			if(nextGridSize < 0) {
				++nextGridSize;
			} else if(nextGridSize >= Enum.GetNames(typeof(GridSetup)).Length) {
				--nextGridSize;
			}

			GameCache.CurrentGridSize = (GridSetup)nextGridSize;
		}
	}
}
