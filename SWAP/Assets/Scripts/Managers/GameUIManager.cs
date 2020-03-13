using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MyBox;

namespace Manager {
	public class GameUIManager : MonoSingleton<GameUIManager> {

		[SerializeField, Tooltip("Pause panel to be displayed when paused.")] private GameObject pausePanel;
		[SerializeField, Tooltip("Cleared panel to be displayed when player cleared the board.")] private GameObject clearedPanel;
		[SerializeField, Tooltip("Time that the player took to cleared the board")] private TextMeshProUGUI clearedTimeTxt;


		protected override void OnAwake() {
		}

		public void TogglePausePanel(bool state) {
			pausePanel.SetActive(state);
			Time.timeScale = (state) ? 0 : 1;
		}

		public void ToggleClearedPanel(bool state) {
			clearedPanel.SetActive(state);
			Time.timeScale = (state) ? 0 : 1;

			clearedTimeTxt.text = GameTimer.Instance.GetGameTime();
		}
	}
}

