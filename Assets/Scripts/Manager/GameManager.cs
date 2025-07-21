using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;



public class GameManager : Singleton<GameManager>
{
    //메뉴
    private OptionUI optionUI;
    private RankingUI rankingUI;

    //인게임

    private ControllerUI controllerUI;
    public ControlType controlType = ControlType.BUTTON;


    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Menu")
        {
            optionUI = FindFirstObjectByType<OptionUI>();
            rankingUI = FindFirstObjectByType<RankingUI>();

            if (optionUI != null) optionUI.gameObject.SetActive(false);
            if (rankingUI != null) rankingUI.gameObject.SetActive(false);
        }
        else if(scene.name == "InGame")
        {
            
        }
    }
}
