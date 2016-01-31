using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Sound : SingletonMonoBehaviour<Sound> {

	private const string BGM_VOLUME_KEY = "BGM_VOLUME_KEY";
	private const string SE_VOLUME_KEY  = "SE_VOLUME_KEY";
	private const float  BGM_VOLUME_DEFULT = 1.0f;
	private const float  SE_VOLUME_DEFULT  = 1.0f;

	public const float BGM_FADE_SPEED_RATE_HIGH = 0.9f;
	public const float BGM_FADE_SPEED_RATE_LOW = 0.3f;
	private float _bgmFadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH;

	private string _nextBGMName;
	private string _nextSEName;

	//BGMをフェードアウト中か
	private bool _isFadeOut = false;

	public AudioSource AttachBGMSource, AttachSESource;


	private void Awake ()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}

		DontDestroyOnLoad (this.gameObject);


	}

	private void Start ()
	{
		AttachBGMSource.volume = PlayerPrefs.GetFloat (BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
		AttachSESource.volume  = PlayerPrefs.GetFloat (SE_VOLUME_KEY,  SE_VOLUME_DEFULT);
	}


	public void PlaySE (string seName, float delay = 0.0f)
	{
		AudioClip clip = GameManager.Get.Resource.GetAudio(seName);
		if (clip == null) return;
		_nextSEName = seName;
		AttachSESource.PlayOneShot(clip);
	}


	public void PlayBGM (string bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
	{
		AudioClip clip = GameManager.Get.Resource.GetAudio(bgmName);
		if (clip == null) return;
		AttachBGMSource.clip = clip;
		if (!AttachBGMSource.isPlaying) {
			AttachBGMSource.Play ();
		}
		else if (AttachBGMSource.clip.name != bgmName) {
			_nextBGMName = bgmName;
			_bgmFadeSpeedRate = fadeSpeedRate;
			_isFadeOut = true;
		}

	}

	public void FadeOutBGM (float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
	{

	}

	private void Update ()
	{
		if (!_isFadeOut) {
			return;
		}

		AttachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;
		if (AttachBGMSource.volume <= 0) {
			AttachBGMSource.Stop ();
			AttachBGMSource.volume = PlayerPrefs.GetFloat (BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
			_isFadeOut = false;

			if (!string.IsNullOrEmpty (_nextBGMName)) {
				PlayBGM(_nextBGMName);
			}
		}

	}


	public void ChangeVolume (float BGMVolume, float SEVolume)
	{
		AttachBGMSource.volume = BGMVolume;
		AttachSESource.volume  = SEVolume;

		PlayerPrefs.SetFloat (BGM_VOLUME_KEY,  BGMVolume);
		PlayerPrefs.SetFloat (SE_VOLUME_KEY,   SEVolume);
	}
}