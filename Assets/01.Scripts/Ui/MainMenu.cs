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
        
        
        
        
        
        
    }
    
    void Start()
    {
        MGSound.instance.init();
        MGSound.instance.playBgm("Main");

        ExitPanel.transform.localScale = Vector3.zero;
        
    }

    
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




   

    

}
