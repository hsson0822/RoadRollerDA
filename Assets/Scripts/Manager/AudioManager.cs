using UnityEngine;
using UnityEngine.SceneManagement;

public enum SFX
{
    BUTTON,
    CRASHCAR,
    OIL,
}

public enum BGM
{
    MENU,
    INGAME,
}

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource BGMSource = null;
    private AudioSource SFXSource = null;

    [SerializeField]
    private AudioClip[] BGMList = { };
    [SerializeField]
    private AudioClip[] SFXList = { };

    private float lastBGMVolume = 0f;
    private float lastSFXVolume = 0f;

    protected override void Awake()
    {
        base.Awake();

        AudioSource[] sources = GetComponents<AudioSource>();
        BGMSource = sources[0];
        SFXSource = sources[1];

        BGMSource.loop = true;
        SFXSource.loop = false;

        BGMSource.volume = 100f;
        SFXSource.volume = 100f;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }

    public static void PlayBGM(BGM _bgmType)
    {
        //int bgmType = (int)_bgmType;
        //Instance.bgmSource.clip = Instance.bgmList[bgmType];
        //Instance.bgmSource.Play();
    }

    public static void PlaySFX(SFX _sfxType, float _distance = 4f)
    {
        //int sfxNumber = (int)_sfxType;
        //Instance.sfxSource.PlayOneShot(Instance.sfxList[sfxNumber], Instance.sfxSource.volume);
    }
    public void StopBGM()
    {
        BGMSource.Stop();
    }

    public void StopSFX()
    {
        SFXSource.Stop();
    }

    public void SetMuteBGM(bool _mute)
    {
        if(_mute)
        {
            lastBGMVolume = BGMSource.volume;
            BGMSource.volume = 0f;
        }
        else
        {
            BGMSource.volume = lastBGMVolume;
        }

        BGMSource.mute = _mute;
    }

    public void SetMuteSFX(bool _mute)
    {
        if (_mute)
        {
            lastSFXVolume = SFXSource.volume;
            SFXSource.volume = 0f;
        }
        else
        {
            SFXSource.volume = lastSFXVolume;
        }

        SFXSource.mute = _mute;
    }
    public void ChangeBGMVolume(float _value)
    {
        BGMSource.volume = _value;
    }

    public void ChangeSFXVolume(float _value)
    {
        SFXSource.volume = _value;
    }

    public float GetVolumeSFX()
    {
        return SFXSource.volume;
    }
    public float GetVolumeBGM()
    {
        return BGMSource.volume;
    }
    public float GetLastBGM()
    {
        return lastBGMVolume;
    }

    public float GetLastSFX()
    {
        return lastSFXVolume;
    }

    public bool GetMuteSFX()
    {
        return SFXSource.mute;
    }
    public bool GetMuteBGM()
    {
        return BGMSource.mute;
    }
}
