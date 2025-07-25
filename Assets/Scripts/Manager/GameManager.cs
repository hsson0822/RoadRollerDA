using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : Singleton<GameManager>
{
    //메뉴
    public MenuUI menuUI;
    public OptionUI optionUI;
    public RankingUI rankingUI;

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
            resetToNull();

            menuUI = FindFirstObjectByType<MenuUI>();
            optionUI = FindFirstObjectByType<OptionUI>();
            rankingUI = FindFirstObjectByType<RankingUI>();

            if (optionUI != null) optionUI.gameObject.SetActive(false);
            if (rankingUI != null) rankingUI.gameObject.SetActive(false);
        }
        else if(scene.name == "InGame")
        {
            resetToNull();

            controllerUI = FindFirstObjectByType<ControllerUI>();
        }
        else
        {
            resetToNull();
        }
    }

    private void resetToNull()
    {
        menuUI = null;
        optionUI = null;
        rankingUI = null;

        controllerUI = null;
    }
}
