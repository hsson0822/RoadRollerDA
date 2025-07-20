using UnityEngine;

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
    [SerializeField]
    private AudioSource sfxSource = null;
    [SerializeField]
    private AudioSource bgmSource = null;

    [SerializeField]
    private AudioClip[] sfxList = { };
    [SerializeField]
    private AudioClip[] bgmList = { };

    protected override void Awake()
    {
        base.Awake();

        this.sfxSource.loop = false;
        this.bgmSource.loop = true;
    }

    public static void PlayBgm(BGM _bgmType)
    {
        int bgmType = (int)_bgmType;
        Instance.bgmSource.clip = Instance.bgmList[bgmType];
        Instance.bgmSource.Play();
    }

    public static void PlaySfx(SFX _sfxType, float _distance = 4f)
    {
        int sfxNumber = (int)_sfxType;
        Instance.sfxSource.PlayOneShot(Instance.sfxList[sfxNumber], Instance.sfxSource.volume);
    }

    public static void StopSfx()
    {
        Instance.sfxSource.Stop();
    }
    public static void StopBgm()
    {
        Instance.bgmSource.Stop();
    }

    public static void SetMuteSfx(bool _mute)
    {
        Instance.sfxSource.mute = _mute;
    }
    public static void SetMuteBgm(bool _mute)
    {
        Instance.bgmSource.mute = _mute;
    }

    public static void ChangeSfxVolume(float _value)
    {
        Instance.sfxSource.volume = _value;
    }
    public static void ChangeBgmVolume(float _value)
    {
        Instance.bgmSource.volume = _value;
    }

    public static float GetVolumeSfx()
    {
        return Instance.sfxSource.volume;
    }
    public static float GetVolumeBgm()
    {
        return Instance.bgmSource.volume;
    }

    public static bool GetMuteSfx()
    {
        return Instance.sfxSource.mute;
    }
    public static bool GetMuteBgm()
    {
        return Instance.bgmSource.mute;
    }
}
