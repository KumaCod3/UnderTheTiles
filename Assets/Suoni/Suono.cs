using UnityEngine;

[System.Serializable]
public class Suono
{
	public string name;
	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;
	[Range(0f, 1f)]
	public float spacialBlend;

	public bool loop;
	public bool playOnAwake;


	[HideInInspector]
	public AudioSource source;

}
