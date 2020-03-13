using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MyBox;

public class GameTimer : MonoSingleton<GameTimer> {
	[SerializeField, Tooltip("Reference to timer text for counting up.")] private TextMeshProUGUI timerTxt;

	public float Minutes { get; private set; }
	public float Seconds { get; private set; }

	protected override void OnAwake() {
	}

	private void Update() {
		UpdateTimer();
	}

	private void UpdateTimer() {
		Minutes = Mathf.Floor(Time.timeSinceLevelLoad / 60);
		Seconds = (Time.timeSinceLevelLoad % 60);


		timerTxt.text = GetGameTime();
	}

	public string GetGameTime() {
		return Minutes.ToString("00") + ":" + Seconds.ToString("00");
	}
}
