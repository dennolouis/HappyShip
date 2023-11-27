using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelSelect, settingSelect;

    //This tells the main menu to slide into the camera
    void Start()
    {
        mainMenu.DOAnchorPos(new Vector2(400,300), 0.25f);
    }

    //This is for the Levels Canvas to slide in... Pretty sure there's a better way to do this...
    public void LevelSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(-400,300),0.25f);
        levelSelect.DOAnchorPos(new Vector2(400,300),0.25f);
        settingSelect.DOAnchorPos(new Vector2(-1200,300),0.25f);
    }
    public void CloseLevelSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(400, 300), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(1200,300),0.25f);
        settingSelect.DOAnchorPos(new Vector2(-400,300),0.25f);
    }
    //This allows Settings Canvas to slide in
    public void SettingSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(1200, 300), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(2000,300),0.25f);
        settingSelect.DOAnchorPos(new Vector2(400,300),0.25f);
    }
    public void CloseSettingSelectButton()
    {
        mainMenu.DOAnchorPos(new Vector2(400, 300), 0.25f);
        levelSelect.DOAnchorPos(new Vector2(1200,300),0.25f);
        settingSelect.DOAnchorPos(new Vector2(-400,300),0.25f);
    }



}
