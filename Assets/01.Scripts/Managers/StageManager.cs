using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Text appleText;
    PlayerScript player;
    public GameObject finish;
    public int _appleCount;
    
    public int _totalAppleCount; //스테이지 마다 인스펙터에서 관리하기 //Find써서 

    public float _achievement;
    public float startX;
    public float finishX;
    public float totalDistance;
    public GameObject[] apples;

    public Button boxCreateBtn;
    public Transform LTrm;
    public Transform RTrm;
    
    void Awake(){
        player = FindObjectOfType<PlayerScript>();
        apples = GameObject.FindGameObjectsWithTag("APPLE");
        finish = GameObject.Find("FINISH");
        _totalAppleCount = apples.Length;
        Debug.Log(_totalAppleCount);
        _appleCount = 0;
        _achievement = 0;
        appleText.text = $"{_appleCount} / {_totalAppleCount}";
        Debug.Log($"{_appleCount} / {_totalAppleCount}");
        startX = player.transform.position.x;
        finishX = finish.transform.position.x;
        totalDistance = finishX - startX;
        DataManager.instance.isPlaying = true;
        if(DataManager.instance.isLeftHand == true)
        {
            boxCreateBtn.transform.position = LTrm.position;
        }
        else
        {
            boxCreateBtn.transform.position = RTrm.position;
        }
    }
    void Start()
    {
        GameObject[] games = GameObject.FindGameObjectsWithTag("BOX_ADD");
        Debug.Log(games.Length);
        if (DataManager.instance.boxSkinIndex == 0)
        {

            
            for (int i = 0; i < games.Length; i++)
            {
                games[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BOX");

            }
        }
        else if (DataManager.instance.boxSkinIndex == 1)
        {
            for (int i = 0; i < games.Length; i++)
            {
                games[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BOX2");
            }
        }

        MGSound.instance.playBgm("Ingame");
    }

    void Update()
    {
        if(DataManager.instance.isPlaying){
            Achievement();
        }
        
    }
    public void Achievement(){
        float curDis = (player.transform.position.x - startX) + (finishX - finish.transform.position.x);
        if(curDis > totalDistance){
            curDis = totalDistance;
        }
        _achievement = (curDis / totalDistance);
        
        //Debug.Log(_achievement);
        //Debug.Log((int)(_achievement * 100) + "%");
    }
    public void AppleUpdate(){
        
        _appleCount++;
        appleText.text = $"{_appleCount} / {_totalAppleCount}";
    }
    public void GameResult(bool _isClear){
        
        DataManager.instance.isClear = _isClear;
        DataManager.instance.appleCount = _appleCount;
        DataManager.instance.totalAppleCount = _totalAppleCount;
        DataManager.instance.achievement = _achievement;
        if(_isClear)
        {
            if(HeartManager.Instance.m_HeartAmount < 10)
            {

                HeartManager.Instance.m_HeartAmount++;
                if (HeartManager.Instance.m_HeartAmount == 10)
                    HeartManager.Instance.m_RechargeRemainTime = 0;
            }
            if((DataManager.instance.cur_index -2) >= DataManager.instance.key)
            {
                DataManager.instance.key++;
                DataManager.instance.Save();
            }

        }
    }
}
