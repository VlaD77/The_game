using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager instance = null;

	public AudioClip[] setPieceSFXs;
	public AudioClip[] buttonClickSFXs;
	public AudioClip matchEndSFX;

	public AudioSource sfxSource;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void PlayRandomSetPieceSFX()
	{
		var randomId = Random.Range(0, setPieceSFXs.Length);
		var randomSFX = setPieceSFXs[randomId];
		PlaySingleSFX(randomSFX, .5f);
	}

	public void PlayRandomButtonClickSFX()
	{
		var randomId = Random.Range(0, buttonClickSFXs.Length);
		var randomSFX = buttonClickSFXs[randomId];
		PlaySingleSFX(randomSFX);
	}

	private void PlaySingleSFX(AudioClip clip, float volume = 1)
	{
		sfxSource.clip = clip;
		sfxSource.volume = volume;
		sfxSource.Play();
	}
}
