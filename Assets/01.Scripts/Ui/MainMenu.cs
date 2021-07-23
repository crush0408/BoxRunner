using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Image Main1;
    public Sprite Main1Change;
    public Sprite Main1Back;

    public Image Main2;
    public Sprite Main2Change;
    public Sprite Main2Back;
    public Slider Volum;
    public Slider Effect;
    public AudioSource BGM;
    public AudioSource[] EffectSound;

    float backVol = 1f;
    float EffVol = 1f;
    public Transform setting;

    // Start is called before the first frame update
    void Start()
    {
        setting.transform.localScale = Vector3.zero;
        backVol = PlayerPrefs.GetFloat("backVol", 1f);
        Volum.value = backVol;
        BGM.volume = Volum.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundCheck();
    }
    public void SoundCheck()
    {
        
        BGM.volume = Volum.value;

        backVol = Volum.value;
        if(backVol <=0)
        {
            Main1.sprite = Main1Change;
        }
        if(backVol >=0.1f)
        {
            Main1.sprite = Main1Back;
        }
        
        PlayerPrefs.SetFloat("backVol", backVol);
    

    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void AudioCon()
    {
        
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
