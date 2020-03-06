using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	[SerializeField, Tooltip("Reference to settings canvas")] private GameObject settingsCanvas;

	public void ToggleSettingPage(bool state) {
		settingsCanvas.SetActive(state);
	}
}
