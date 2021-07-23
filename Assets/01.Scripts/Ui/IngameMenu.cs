using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IngameMenu : MonoBehaviour
{
    public Slider StageCurBar;
    StageManager stageManager;
    public Transform StopMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        StopMenu.transform.localScale = Vector3.zero;
        
    }
    void Awake()
    {
        stageManager = FindObjectOfType<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StageCur();  
    }

    void StageCur()
    {
        StageCurBar.value = stageManager._achievement * 100;
    }


    public void StopMenuOpen()
    {
        StopMenu.DOScale(new Vector3(1, 1, 1), 0.2f).OnComplete(delegate ()
        {
            Time.timeScale = 0f;
        });
    }
    public void StopMenuClose()
    {
        Time.timeScale = 1f;
        StopMenu.DOScale(new Vector3(0, 0, 0), 0.2f);
    }

}
