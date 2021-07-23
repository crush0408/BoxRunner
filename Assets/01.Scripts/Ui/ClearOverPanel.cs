using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearOverPanel : MonoBehaviour
{
    public StageSelect stageSelect;
    
    void Start()
    {

    }
    void Awake()
    {
        stageSelect = FindObjectOfType<StageSelect>();
        Debug.Log(stageSelect.index);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectStage()
    {

        SceneManager.LoadScene("LevelSelect");
        //SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void nextStage()
    {
        for (int i = 0; i < stageSelect.Stages.Length; i++)
        {
            switch (i)
            {
                case 0:
                    SceneManager.LoadScene(2);
                    break;
                case 1:
                    SceneManager.LoadScene(3);
                    break;
                case 2:
                    SceneManager.LoadScene(4);
                    break;
            }
        }
    }
    public void RetryStage()
    {
        SceneManager.LoadScene(stageSelect.index + 1);
        

        if(stageSelect.index == 0)
        {
            SceneManager.LoadScene(1);
        }
        if(stageSelect.index == 1)
        {
            SceneManager.LoadScene(2);
        }
        if(stageSelect.index == 2)
        {
            SceneManager.LoadScene(3);
        }
        if(stageSelect.index == 3)
        {
            SceneManager.LoadScene(4);
        }
    }
}
