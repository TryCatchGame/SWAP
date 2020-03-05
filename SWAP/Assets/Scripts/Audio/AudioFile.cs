using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioFile {
	public AudioType AudioType;
	public AudioClip Clip;

	public bool PlayOnAwake;
	public bool IsLooping;

	public AudioMixerGroup mixerGroup;

	[Range(0f, 1f)] public float AudioVolume = 1f;
	[HideInInspector] public AudioSource Source;
}
