using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> {
	[SerializeField, Tooltip("Contains all the audios in the game.")] private AudioFile[] audioFiles = default;

	private static Dictionary<AudioType, AudioFile> audioDict;

	private void Awake() {
		if(audioDict != null) return;

		audioDict = new Dictionary<AudioType, AudioFile>();

		InitializeAudioDict();
		InitializeAudioFiles();
	}

	#region Initialization

	/// <summary>
	/// Add all the type of audios into the dictionary.
	/// </summary>
	private void InitializeAudioDict() {
		foreach(AudioFile audioFile in audioFiles) {
			audioDict.Add(audioFile.AudioType, audioFile);
		}
	}

	/// <summary>
	/// Create an audio source component for each audio clip and initialize with the audio file properties.
	/// </summary>
	private void InitializeAudioFiles() {
		foreach(var a in audioFiles) {
			a.Source = gameObject.AddComponent<AudioSource>();

			// Assign audio properties to the newly created audio source.
			a.Source.clip = a.Clip;
			a.Source.volume = a.AudioVolume;
			a.Source.loop = a.IsLooping;
			a.Source.outputAudioMixerGroup = a.mixerGroup;

			// Start playing the audio if needed.
			if(a.PlayOnAwake) {
				a.Source.Play();
			}
		}
	}

	#endregion

	/// <summary>
	/// Play an audio of the given type and volume.
	/// </summary>
	public void PlayOneShot(AudioType audioType, float volume = 1f) {
		// Get audio file from dictionary.
		audioDict.TryGetValue(audioType, out AudioFile audioFile);

		// Play audio if there is such audio file of the given type.
		if(audioFile != null) {
			audioFile.Source.PlayOneShot(audioFile.Clip, volume);
		} else {
			Debug.LogError("Audio clip for " + audioType + " has not been assigned.");
		}
	}
}
