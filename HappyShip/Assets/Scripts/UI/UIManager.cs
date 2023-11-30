using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelSelect, settingSelect;
    
    int screenHeight = 300;
    int mainScreen = 400;
    

    //This tells the main menu to slide into the camera
    void Start()
    {
        mainMenu.DOAnchorPos(new Vector2(mainScreen, screenHeight), 0.25f);
    }

    //This is for the Levels Canvas to slide in... Pretty sure there's a better way to do this...
    public void LevelSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(-mainScreen, screenHeight),0.25f);
        levelSelect.DOAnchorPos(new Vector2(mainScreen , screenHeight ),0.25f);
        settingSelect.DOAnchorPos(new Vector2(mainScreen * -3, screenHeight), 0.25f);
    }
    public void CloseLevelSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(mainScreen, screenHeight), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(mainScreen * 3, screenHeight),0.25f);
        settingSelect.DOAnchorPos(new Vector2(-mainScreen, screenHeight),0.25f);
    }
    //This allows Settings Canvas to slide in
    public void SettingSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(mainScreen * 3, screenHeight), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(mainScreen * 5, screenHeight),0.25f);
        settingSelect.DOAnchorPos(new Vector2(mainScreen, screenHeight),0.25f);
    }
    public void CloseSettingSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(mainScreen, screenHeight), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(mainScreen * 3, screenHeight),0.25f);
        settingSelect.DOAnchorPos(new Vector2(-mainScreen, screenHeight),0.25f);
    }



}
