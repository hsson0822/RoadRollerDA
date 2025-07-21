using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;


    private void OnEnable()
    {
        returnButton.onClick.AddListener(OnClickReturnButton);
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
}
