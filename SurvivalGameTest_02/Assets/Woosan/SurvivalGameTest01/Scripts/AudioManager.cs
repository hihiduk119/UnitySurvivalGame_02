using UnityEngine;
using System.Collections;
using Woosan.Common;

using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

using DG.Tweening;

public enum SoundOneshot {
	RifleOne_00
}


public class AudioManager : MonoSingleton<AudioManager> {
    public AudioClip[] oneShotClipArr;
    public AudioClip[] loopClipArr;

    public AudioMixerSnapshot GunS;
    public AudioMixerSnapshot GunE;

    private AudioSource[] audioOneShotSourceArr = new AudioSource[4];
    //private AudioSource[] audioLoopSourceArr = new AudioSource[4];
    int audioCnt = 0;
    Coroutine corRifleShot;
    public AudioMixer mixer;

    [Range(0, 1)]
    public float delay;

    AudioSource auto;
    AudioSource eco;

    public bool shootEnd = false;

    public override void Init() {
        base.Init();

        for (int index = 0; index < audioOneShotSourceArr.Length; index++)
        {
            this.audioOneShotSourceArr[index] = this.gameObject.AddComponent<AudioSource>();
        }

        //for (int index = 0; index < audioLoopSourceArr.Length; index++)
        //{
        //    this.audioLoopSourceArr[index] = this.gameObject.AddComponent<AudioSource>();
        //}

        auto = GetComponents<AudioSource>()[0];
        eco = GetComponents<AudioSource>()[1];
    }


    void Lowpass()
    {
        if (shootEnd)
        {
            GunE.TransitionTo(0.5f);
        }
        else
        {
            GunS.TransitionTo(0.01f);
        }
    }

    public void Mute(bool isMute) {
		for(int index = 0 ; index < this.audioOneShotSourceArr.Length;index++)
			this.audioOneShotSourceArr[index].mute = isMute;

		//for(int index = 0 ; index < this.audioLoopSourceArr.Length;index++)
		//	this.audioLoopSourceArr[index].mute = isMute;


	}

	public void OneShot(SoundOneshot index) {
//		Debug.Log("OneShot index = " + index);
		bool run = false;
		for(int sourceIndex = 0; sourceIndex < audioOneShotSourceArr.Length;sourceIndex++ ) {
			if(!audioOneShotSourceArr[sourceIndex].isPlaying) {
				audioOneShotSourceArr[sourceIndex].clip = oneShotClipArr[(int)index];
				audioOneShotSourceArr[sourceIndex].volume = 1f;
				audioOneShotSourceArr[sourceIndex].Play();
				run = true;
                
                return;
			}

			//마지막까지 실행을 못했다면
			if(audioOneShotSourceArr.Length -1 == sourceIndex && !run) {
				audioOneShotSourceArr[audioCnt].clip = oneShotClipArr[(int)index];
				audioOneShotSourceArr[audioCnt].volume = 1f;
				audioOneShotSourceArr[audioCnt].Play();
                audioCnt++;
                if (audioCnt >= audioOneShotSourceArr.Length)
                    audioCnt = 0;
                Debug.Log(audioCnt);
			}
		}
	}

    void RifleShot()
    {
        auto.Play();

        shootEnd = false;
        Lowpass();
    }


    void RifleShotStop() {
        eco.Play();

        shootEnd = true;
        Lowpass();
    }

	public void OneShot(SoundOneshot index,float volume) {
//		if(!LocalData.soundAble)
//			return;

		bool run = false;
		for(int sourceIndex = 0; sourceIndex < audioOneShotSourceArr.Length;sourceIndex++ ) {
			if(!audioOneShotSourceArr[sourceIndex].isPlaying) {
				audioOneShotSourceArr[sourceIndex].clip = oneShotClipArr[(int)index];
				audioOneShotSourceArr[sourceIndex].volume = volume;
				audioOneShotSourceArr[sourceIndex].Play();
				run = true;
				return;
			}

			//마지막까지 실행을 못했다면
			if(audioOneShotSourceArr.Length -1 == sourceIndex && !run) {
				audioOneShotSourceArr[0].clip = oneShotClipArr[(int)index];
				audioOneShotSourceArr[0].volume = volume;
				audioOneShotSourceArr[0].Play();
			}
		}
	}

	public void StopOnShot() {
		for(int index = 0; index < audioOneShotSourceArr.Length;index++) {
			audioOneShotSourceArr[index].Stop();
		}
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 150), "auto"))
        {
            RifleShot();
        }

        if (GUI.Button(new Rect(0, 150, 200, 150), "stop"))
        {
            RifleShotStop();
        }

        if (GUI.Button(new Rect(0, 300, 200, 150), "one"))
        {
            OneShot(SoundOneshot.RifleOne_00);
        }
    }
}
