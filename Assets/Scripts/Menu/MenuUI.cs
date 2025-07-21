using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button rankingButton;


    private void OnEnable()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        optionButton.onClick.AddListener(OnClickOptionButton);
        rankingButton.onClick.AddListener(OnClickRankingButton);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnClickStartButton);
        optionButton.onClick.RemoveListener(OnClickOptionButton);
        rankingButton.onClick.RemoveListener(OnClickRankingButton);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    private void OnClickOptionButton()
    {
        if (GameManager.Instance.optionUI!= null) GameManager.Instance.optionUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnClickRankingButton()
    {
        if (GameManager.Instance.rankingUI != null) GameManager.Instance.rankingUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
