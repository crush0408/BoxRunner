using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
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
        EffVol = PlayerPrefs.GetFloat("EffVol", 1f);
        Volum.value = backVol;
        Effect.value = EffVol;
        BGM.volume = Volum.value;
        for(int i = 0; i < EffectSound.Length; i++)
        {
            EffectSound[i].volume = Effect.value;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundCheck();
    }
    public void SoundCheck()
    {
        for(int i = 0; i < EffectSound.Length; i++)
        {
            EffectSound[i].volume = Effect.value;
        }
        BGM.volume = Volum.value;

        backVol = Volum.value;
        EffVol = Effect.value;
        PlayerPrefs.SetFloat("backVol", backVol);
        PlayerPrefs.SetFloat("EffVol", EffVol);

    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
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
