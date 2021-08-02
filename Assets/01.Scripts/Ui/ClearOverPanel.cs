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
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
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
        Point[1].text = string.Format("{0:n0} %", _achievement * 100);
        Point[2].text = _appleCount.ToString();
        if (DataManager.instance.isClear)
        {
            Point[0].text = "성공";
        }
        else
        {
            Point[0].text = "실패";
        }
        Point[3].text = $"{_appleCount} / {_totalAppleCount}";
        if(_appleCount == 4){
            g1.gameObject.SetActive(true);
            g2.gameObject.SetActive(true);
            g3.gameObject.SetActive(true);
        }
        else if(_appleCount == 3 || _appleCount == 2){
            g1.gameObject.SetActive(true);
            g2.gameObject.SetActive(true);
        }
        else{
            g1.gameObject.SetActive(true);
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
