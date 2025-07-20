using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    private OptionUI optionUI;
    private RankingUI rankingUI;

    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button rankingButton;


    private void OnEnable()
    {
        optionUI = FindFirstObjectByType<OptionUI>();
        rankingUI = FindFirstObjectByType<RankingUI>();

        startButton.onClick.AddListener(OnClickStartButton);
        optionButton.onClick.AddListener(OnClickOptionButton);
        rankingButton.onClick.AddListener(OnClickRankingButton);
    }

    private void OnDisable()
    {
        optionUI = null;
        rankingUI = null;

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
        if (optionUI!= null) optionUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnClickRankingButton()
    {
        if (rankingUI!= null) rankingUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
