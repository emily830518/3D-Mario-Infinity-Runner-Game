using UnityEngine;
using System.Collections;

public class SoundManager/*: MonoBehaviour*/
{
    //public AudioSource EffectsSrc;
    //public AudioSource MusicSrc;

    public static SoundManager instance { 
        get{ 
            if(_soundmanger==null){
                _soundmanger = new SoundManager();
            }
            return _soundmanger;
        }
    }

    private static SoundManager _soundmanger;

    //public static SoundManager instance = null;
    //void Awake()
    //{
    //    //Check if there is already an instance of SoundManager
    //    if (instance == null)
    //        //if not, set it to this.
    //        instance = this;
    //    //If instance already exists:
    //    else if (instance != this)
    //        //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
    //        Destroy(gameObject);
    //}


    //Used to play single sound clips.
    public void PlayMusic(AudioSource MusicSrc,AudioClip clip)
    {
        MusicSrc.clip = clip;
        //Debug.Log(clip);
        MusicSrc.Play();
    }

    public void Play(AudioSource EffectsSrc, AudioClip clip)
    {
        EffectsSrc.clip = clip;
        //Debug.Log(clip);
        EffectsSrc.Play();
    }
}