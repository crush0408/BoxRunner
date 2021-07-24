using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearOverPanel : MonoBehaviour
{
    public Text[] Point;
    public int _index;
    public float _achievement;
    public int _appleCount;
    public int _totalAppleCount;
    public bool _isClear;
    void Start()
    {
        InitData();
    }
    private void InitData()
    {
        _index = DataManager.instance.cur_index;
        _achievement = DataManager.instance.achievement;
        _appleCount = DataManager.instance.appleCount;
        _totalAppleCount = DataManager.instance.totalAppleCount;
        _isClear = DataManager.instance.isClear;
    }
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Point[0].text = DataManager.instance.isClear.ToString();
        Point[1].text = string.Format("{0:n0}", _achievement * 100);
        Point[2].text = _appleCount.ToString();
        if (DataManager.instance.isClear)
        {
            Point[0].text = "성공";
        }
        else
        {
            Point[0].text = "실패";
        }

    }
    public void SelectStage()
    {
        SceneManager.LoadScene("LevelSelect");
        //SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void nextStage()
    {
        SceneManager.LoadScene(_index + 1);
    }
    public void RetryStage()
    {
        SceneManager.LoadScene(_index);
    }
}
