using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;



public class MainMenu : MonoBehaviour
{
    public Text MainLogoText;
    public Transform ExitPanel;
   

    void Awake()
    {
    
        MGSound.instance.init();
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ExitPanel.transform.localScale = Vector3.zero;
    }

    //void BlinkText()
    //{
    //    textCool += Time.deltaTime;
    //    if(textCool <= joinCool)
    //    {
    //        MainLogoText.enabled = false;
    //        textCool = 0;
    //    }
    //    if(textCool == 0)
    //    {
    //        MainLogoText.enabled = true;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //BlinkText();
        
    }
    
    public void OpenP()
    {
        ExitPanel.DOScale(new Vector3(1, 1, 1), 0.2f);
    }

    public void CloseP()
    {
        ExitPanel.DOScale(new Vector3(0, 0, 0), 0.2f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void AudioCon()
    {
       MGSound.instance.AdjustVolume();
    }


   

    

}
