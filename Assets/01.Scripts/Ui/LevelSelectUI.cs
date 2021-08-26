using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelSelectUI : MonoBehaviour
{ 
    public Image Main1;
    public Sprite Main1Change;
    public Sprite Main1Back;

    public Image Main2;
    public Sprite Main2Change;
    public Sprite Main2Back;
    public Slider Volum;
    public Slider Effect;

    float textCool = 0;
    float joinCool = 1;


    float backVol = 1f;
    float EffVol = 1f;
    public Transform setting;
    // Start is called before the first frame update
    void Start()
    {
        MGSound.instance.playBgm("Main");
        DataManager.instance.BGMmasterSoundVolume = 1f;
        setting.transform.localScale = Vector3.zero;
        backVol = PlayerPrefs.GetFloat("backVol", 1f);
        EffVol = PlayerPrefs.GetFloat("EffVol", 1f);
        Volum.value = backVol;
        Effect.value = EffVol;
        DataManager.instance.BGMmasterSoundVolume = Volum.value;
        DataManager.instance.EFFmasterSoundVolume = Effect.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundCheck();
    }
    
    public void SoundCheck()
    {

        DataManager.instance.BGMmasterSoundVolume = Volum.value;
        DataManager.instance.EFFmasterSoundVolume = Effect.value;
        EffVol = Effect.value;
        backVol = Volum.value;
        if (EffVol <= 0)
        {
            Main2.sprite = Main2Change;
        }
        if (EffVol >= 0.1f)
        {
            Main2.sprite = Main2Back;
        }

        if (backVol <= 0)
        {
            Main1.sprite = Main1Change;
        }
        if (backVol >= 0.1f)
        {
            Main1.sprite = Main1Back;
        }

        PlayerPrefs.SetFloat("backVol", backVol);
        PlayerPrefs.SetFloat("EffVol", EffVol);


    }
    
    public void OpenSetting()
    {
        setting.DOScale(new Vector3(1, 1, 1), 0.2f);
    }
    public void CloseSetting()
    {
        setting.DOScale(new Vector3(0, 0, 0), 0.2f);
    }
}
