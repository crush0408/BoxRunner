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
        InitData();
    }

    // Update is called once per frame
    void Start()
    {
        
        Point[0].text = DataManager.instance.isClear.ToString();
        Point[1].text = string.Format("{0:n0} %", _achievement * 100);
        Point[2].text = _appleCount.ToString();
        if (DataManager.instance.isClear)
        {
            Point[0].text = "성공";
            if(_appleCount == _totalAppleCount){
                
                g2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Star");
                g3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Star");
                
            }
            else if(_totalAppleCount - 1 == _appleCount){
                
                g2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Star");
            }
            
            g1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Star");
            MGSound.instance.playBgm("Clear");
            
        }
        else
        {
            Point[0].text = "실패";
            MGSound.instance.stopBgm();
            MGSound.instance.playEff("Fail");
        }
        Point[3].text = $"{_appleCount} / {_totalAppleCount}";
        
    }
    public void SelectStage()
    {
        SceneManager.LoadScene("LevelSelect");
        //SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void nextStage()
    {
        if(DataManager.instance.key >= _index - 1 && HeartManager.Instance.m_HeartAmount > 0 && (_index -1) < 2)
        {
            HeartManager.Instance.OnClickUseHeart();

            GameObject a = Instantiate(HeartManager.Instance.heartResumePanel);
            a.transform.SetParent(this.gameObject.transform, false);

            StartCoroutine(HeartPanel2());

            
        }
        else if(DataManager.instance.key >= _index - 1)
        {
            GameObject a = Instantiate(HeartManager.Instance.heartlowPanel);
            a.transform.SetParent(this.gameObject.transform, false);
        }
    }
    public void RetryStage()
    {
        if(HeartManager.Instance.m_HeartAmount > 0)
        {
            HeartManager.Instance.OnClickUseHeart();

            GameObject a = Instantiate(HeartManager.Instance.heartResumePanel);
            a.transform.SetParent(this.gameObject.transform, false);

            StartCoroutine(HeartPanel());
        }
        else
        {
            GameObject a = Instantiate(HeartManager.Instance.heartlowPanel);
            a.transform.SetParent(this.gameObject.transform, false);
        }

    }
    IEnumerator HeartPanel()
    {
        Debug.Log("gd");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_index);
    }
    IEnumerator HeartPanel2()
    {
        yield return new WaitForSeconds(1f);
        _index++;
        DataManager.instance.cur_index++;
        DataManager.instance.isClear = false;
        SceneManager.LoadScene(_index);

    }
}
