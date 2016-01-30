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

	private Dictionary<string, AudioClip> _bgmDic, _seDic;

	private void Awake ()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}

		DontDestroyOnLoad (this.gameObject);

		_bgmDic = new Dictionary<string, AudioClip> ();
		_seDic  = new Dictionary<string, AudioClip> ();

		object[] bgmList = Resources.LoadAll ("/Audios/BGM");
		object[] seList  = Resources.LoadAll ("Audios");

		foreach (AudioClip bgm in bgmList) {
			_bgmDic [bgm.name] = bgm;
		}
		foreach (AudioClip se in seList) {
			_seDic [se.name] = se;
		}
	}

	private void Start ()
	{
		AttachBGMSource.volume = PlayerPrefs.GetFloat (BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
		AttachSESource.volume  = PlayerPrefs.GetFloat (SE_VOLUME_KEY,  SE_VOLUME_DEFULT);
	}


	public void PlaySE (string seName, float delay = 0.0f)
	{
		if (!_seDic.ContainsKey (seName)) {
			Debug.Log (seName + "という名前のSEがありません");
			return;
		}

		_nextSEName = seName;
		Invoke ("DelayPlaySE", delay);
	}

	private void DelayPlaySE ()
	{
		AttachSESource.PlayOneShot (_seDic [_nextSEName] as AudioClip);
	}


	public void PlayBGM (string bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
	{
		if (!_bgmDic.ContainsKey (bgmName)) {
			Debug.Log (bgmName + "という名前のBGMがありません");
			return;
		}

		if (!AttachBGMSource.isPlaying) {
			_nextBGMName = "";
			AttachBGMSource.clip = _bgmDic [bgmName] as AudioClip;
			AttachBGMSource.Play ();
		}
		else if (AttachBGMSource.clip.name != bgmName) {
			_nextBGMName = bgmName;
			FadeOutBGM (fadeSpeedRate);
		}

	}
		
	public void FadeOutBGM (float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
	{
		_bgmFadeSpeedRate = fadeSpeedRate;
		_isFadeOut = true;
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
				PlayBGM (_nextBGMName);
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