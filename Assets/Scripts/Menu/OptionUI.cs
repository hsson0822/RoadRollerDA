using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private Toggle[] controlToggles = new Toggle[3];


    private void OnEnable()
    {
        returnButton.onClick.AddListener(OnClickReturnButton);

        for(int i = 0; i < 3; ++i)
            controlToggles[i].onValueChanged.AddListener(delegate { SelectControlType(); });
    }

    private void OnDisable()
    {
        returnButton.onClick.RemoveListener(OnClickReturnButton);
    }

    private void OnClickReturnButton()
    {
        if (GameManager.Instance.menuUI != null) GameManager.Instance.menuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    private void SelectControlType()
    {
        for (int i = 0; i < 3; ++i)
            if (controlToggles[i].isOn)
                GameManager.Instance.controlType = (ControlType)i;

        Debug.Log(GameManager.Instance.controlType);
    }
}
