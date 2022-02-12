using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class LevelSelectUI : MonoBehaviour
{ 
    public Image Main1;
    public Sprite Main1Change;
    public Sprite Main1Back;

    public GameObject skinBtn;

    public Image Main2;
    public Sprite Main2Change;
    public Sprite Main2Back;
    public Slider Volum;
    public Slider Effect;

    public Text heart;
    public Text remainH_Time;
    //public Button playBtn;

    float backVol = 1f;
    float EffVol = 1f;
    public Transform settingPanel;
    public Transform characterPanel;
    // Start is called before the first frame update
    void Start()
    {
        settingPanel.transform.localScale = Vector3.zero;
        characterPanel.transform.localScale = Vector3.zero;

        
        backVol = DataManager.instance.BGMmasterSoundVolume;
        EffVol = DataManager.instance.EFFmasterSoundVolume;

        
        //MGSound.instance.playBgm("Main");
        //PlayerPrefs.SetFloat("BGM", backVol);
        //PlayerPrefs.SetFloat("EFF", EffVol);
        
        Volum.value = backVol;
        Effect.value = EffVol;

        

        CurBoxSkin();

        MGSound.instance.playBgm("Select");
    }

    // Update is called once per frame
    void Update()
    {
        heart.text = HeartManager.Instance.m_HeartAmount.ToString();
        remainH_Time.text = HeartManager.Instance.m_RechargeRemainTime.ToString();
    }
    
    public void BGMControl()
    {
        backVol = Volum.value;
        DataManager.instance.BGMmasterSoundVolume = backVol;
        MGSound.instance.AdjustVolume();
        if (backVol <= 0)
        {
            Main1.sprite = Main1Change;
        }
        if (backVol >= 0.1f)
        {
            Main1.sprite = Main1Back;
        }
        PlayerPrefs.SetFloat("BGM", backVol);
        
    }
    public void EFFControl()
    {
        EffVol = Effect.value;
        DataManager.instance.EFFmasterSoundVolume = EffVol;
        if (EffVol <= 0)
        {
            Main2.sprite = Main2Change;
        }
        if (EffVol >= 0.1f)
        {
            Main2.sprite = Main2Back;
        }
        PlayerPrefs.SetFloat("EFF", EffVol);
    }
    
    public void OpensettingPanel()
    {
        if(characterPanel.localScale == new Vector3(1,1,1)){
            CloseCharacterPanel();
        }
        settingPanel.DOScale(new Vector3(1, 1, 1), 0.2f);
        
    }
    public void ClosesettingPanel()
    {
        settingPanel.DOScale(new Vector3(0, 0, 0), 0.2f);
    }
    public void OpenCharacterPanel()
    {
        if(settingPanel.localScale == new Vector3(1,1,1)){
            ClosesettingPanel();
        }
        characterPanel.DOScale(new Vector3(1, 1, 1), 0.2f);
    }
    public void CloseCharacterPanel()
    {
        characterPanel.DOScale(new Vector3(0, 0, 0), 0.2f);
    }
    public void SkinSwap(){

        DataManager.instance.boxSkinIndex = (DataManager.instance.boxSkinIndex + 1) % 2; // 맥스 스킨 값 으로 나눈 나머지
        PlayerPrefs.SetInt("BOXSKIN", DataManager.instance.boxSkinIndex);
        CurBoxSkin();
    }
    public void CurBoxSkin()
    {
        if (DataManager.instance.boxSkinIndex == 0)
        {
            skinBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("BOX");
        }
        else if (DataManager.instance.boxSkinIndex == 1)
        {
            skinBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("BOX2");
        }
    }
}
