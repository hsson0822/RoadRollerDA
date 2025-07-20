using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    private MenuUI menuUI;

    [SerializeField] private Button returnButton;


    private void OnEnable()
    {
        menuUI= FindFirstObjectByType<MenuUI>();
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    private void OnDisable()
    {
        menuUI = null;
        returnButton.onClick.RemoveListener(OnClickReturnButton);
    }

    private void OnClickReturnButton()
    {
        if (menuUI != null) menuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
