using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] private Toggle BGMMuteToggle;
    [SerializeField] private Toggle SFXMuteToggle;

    [SerializeField] private Toggle[] controlToggles = new Toggle[3];


    private void OnEnable()
    {
        returnButton.onClick.AddListener(OnClickReturnButton);

        for (int i = 0; i < 3; ++i)
            controlToggles[i].onValueChanged.AddListener(delegate { SelectControlType(); });

        BGMMuteToggle.onValueChanged.AddListener(MuteBGM);
        SFXMuteToggle.onValueChanged.AddListener(MuteSFX);

        BGMSlider.onValueChanged.AddListener(ChangeBGMVolume);
        SFXSlider.onValueChanged.AddListener(ChangeSFXVolume);

        GetBGMVolume();
        GetSFXVolume();

    }

    private void OnDisable()
    {
        returnButton.onClick.RemoveListener(OnClickReturnButton);

        for (int i = 0; i < 3; ++i)
            controlToggles[i].onValueChanged.RemoveListener(delegate { SelectControlType(); });

        BGMMuteToggle.onValueChanged.RemoveListener(MuteBGM);
        SFXMuteToggle.onValueChanged.RemoveListener(MuteSFX);

        BGMSlider.onValueChanged.RemoveListener(ChangeBGMVolume);
        SFXSlider.onValueChanged.RemoveListener(ChangeSFXVolume);
    }

    private void OnClickReturnButton()
    {
        if (GameManager.Instance.menuUI != null) GameManager.Instance.menuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void GetBGMVolume()
    {
        //Debug.Log("BGM : " + AudioManager.Instance.GetVolumeBGM());
        BGMSlider.value = AudioManager.Instance.GetVolumeBGM();
    }

    private void GetSFXVolume()
    {
        //Debug.Log("SFX : " + AudioManager.Instance.GetVolumeSFX());
        SFXSlider.value = AudioManager.Instance.GetVolumeSFX();
    }

    private void ChangeBGMVolume(float value)
    {
        AudioManager.Instance.ChangeBGMVolume(BGMSlider.value);
        
        if(BGMMuteToggle.isOn)
        {
            AudioManager.Instance.SetMuteBGM(false);
            BGMMuteToggle.SetIsOnWithoutNotify(false);
        }

        //Debug.Log("BGM : " + BGMSlider.value);
    }

    private void ChangeSFXVolume(float value)
    {
        AudioManager.Instance.ChangeSFXVolume(SFXSlider.value);

        if (SFXMuteToggle.isOn)
        {
            AudioManager.Instance.SetMuteSFX(false);
            SFXMuteToggle.SetIsOnWithoutNotify(false);
        }

        //Debug.Log("SFX : " + SFXSlider.value);
    }

    private void MuteBGM(bool isOn)
    {
        AudioManager.Instance.SetMuteBGM(isOn);
        BGMSlider.SetValueWithoutNotify(AudioManager.Instance.GetVolumeBGM());
        //Debug.Log("MUTE : " + AudioManager.Instance.GetVolumeBGM());
    }

    private void MuteSFX(bool isOn)
    {
        AudioManager.Instance.SetMuteSFX(isOn);
        SFXSlider.SetValueWithoutNotify(AudioManager.Instance.GetVolumeSFX());
        //Debug.Log("MUTE : " + AudioManager.Instance.GetVolumeSFX());
    }

    private void SelectControlType()
    {
        for (int i = 0; i < 3; ++i)
            if (controlToggles[i].isOn)
                GameManager.Instance.controlType = (ControlType)i;

        //Debug.Log(GameManager.Instance.controlType);
    }
}
