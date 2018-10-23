using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	AudioSource[] audioSources;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSources = GetComponents<AudioSource>();
	}
	
	public void Play(int soundIndex)
	{
		audioSources[soundIndex].Play();
	}
}
