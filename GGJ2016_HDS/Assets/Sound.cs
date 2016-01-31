using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound : SingletonMonoBehaviour<Sound> {



<<<<<<< HEAD

	protected static Sound instance;
=======
	public AudioSource AttachBGMSource, AttachSESource;
    
>>>>>>> a4c573256b6c30a10edb66c2b483466369a63c1d

	public static Sound Instance
	{
		get
		{
			if(instance == null)
			{
				instance = (Sound) FindObjectOfType(typeof(Sound));

				if (instance == null)
				{
					Debug.LogError("SoundManager Instance Error");
				}
			}

			return instance;
		}
	}

	// 音量
//	public SoundVolume volume = new SoundVolume();

	// === AudioSource ===
	// BGM
	private AudioSource BGMsource;
	// SE
	private AudioSource[] SEsources = new AudioSource[16];
	// 音声
	private AudioSource[] VoiceSources = new AudioSource[16];

	// === AudioClip ===
	// BGM
	public AudioClip[] BGM;
	// SE
	public AudioClip[] SE;
	// 音声
	public AudioClip[] Voice;

	void Awake (){
		GameObject[] obj = GameObject.FindGameObjectsWithTag("SoundManager");
		if( obj.Length > 1 ){
			// 既に存在しているなら削除
			Destroy(gameObject);
		}else{
			// 音管理はシーン遷移では破棄させない
			DontDestroyOnLoad(gameObject);
		}

<<<<<<< HEAD
		// 全てのAudioSourceコンポーネントを追加する

		// BGM AudioSource
		BGMsource = gameObject.AddComponent<AudioSource>();
		// BGMはループを有効にする
		BGMsource.loop = true;

		// SE AudioSource
		for(int i = 0 ; i < SEsources.Length ; i++ ){
			SEsources[i] = gameObject.AddComponent<AudioSource>();
		}

		// 音声 AudioSource
		for(int i = 0 ; i < VoiceSources.Length ; i++ ){
			VoiceSources[i] = gameObject.AddComponent<AudioSource>();
		}
=======

>>>>>>> a4c573256b6c30a10edb66c2b483466369a63c1d
	}

	void Update () {

	}


<<<<<<< HEAD

	// ***** BGM再生 *****
	// BGM再生
	public void PlayBGM(int index){
		if( 0 > index || BGM.Length <= index ){
			return;
		}
		// 同じBGMの場合は何もしない
		if( BGMsource.clip == BGM[index] ){
			return;
		}
		BGMsource.Stop();
		BGMsource.clip = BGM[index];
		BGMsource.Play();
	}

	// BGM停止
	public void StopBGM(){
		BGMsource.Stop();
		BGMsource.clip = null;
	}


	// ***** SE再生 *****
	// SE再生
	public void PlaySE(int index){
		if( 0 > index || SE.Length <= index ){
			return;
		}

		// 再生中で無いAudioSouceで鳴らす
		foreach(AudioSource source in SEsources){
			if( false == source.isPlaying ){
				source.clip = SE[index];
				source.Play();
				return;
			}
		}  
	}

	// SE停止
	public void StopSE(){
		// 全てのSE用のAudioSouceを停止する
		foreach(AudioSource source in SEsources){
			source.Stop();
			source.clip = null;
		}  
=======
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

>>>>>>> a4c573256b6c30a10edb66c2b483466369a63c1d
	}


	// ***** 音声再生 *****
	// 音声再生
	public void PlayVoice(int index){
		if( 0 > index || Voice.Length <= index ){
			return;
		}
<<<<<<< HEAD
		// 再生中で無いAudioSouceで鳴らす
		foreach(AudioSource source in VoiceSources){
			if( false == source.isPlaying ){
				source.clip = Voice[index];
				source.Play();
				return;
=======

		AttachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;
		if (AttachBGMSource.volume <= 0) {
			AttachBGMSource.Stop ();
			AttachBGMSource.volume = PlayerPrefs.GetFloat (BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
			_isFadeOut = false;

			if (!string.IsNullOrEmpty (_nextBGMName)) {
                PlayBGM(_nextBGMName);
>>>>>>> a4c573256b6c30a10edb66c2b483466369a63c1d
			}
		} 
	}

	// 音声停止
	public void StopVoice(){
		// 全ての音声用のAudioSouceを停止する
		foreach(AudioSource source in VoiceSources){
			source.Stop();
			source.clip = null;
		}  
	}


}
