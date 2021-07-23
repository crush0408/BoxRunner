using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int apple;
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

    
    void Awake(){
        player = FindObjectOfType<PlayerScript>();
        apples = GameObject.FindGameObjectsWithTag("APPLE");
        finish = GameObject.Find("FINISH");
        _totalAppleCount = apples.Length;
        Debug.Log(_totalAppleCount);
        apple = 0;
        appleText.text = $"apple : {apple}";

        startX = player.transform.position.x;
        finishX = finish.transform.position.x;
        totalDistance = finishX - startX;
    }
    void Start()
    {
        
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            Achievement();
        }
    }
    public void Achievement(){
        float curDis = player.transform.position.x - startX;
        _achievement = (curDis / totalDistance);
        Debug.Log(_achievement);
        Debug.Log((int)(_achievement * 100) + "%");
    }
    public void AppleUpdate(){
        apple++;
        appleText.text = $"apple : {apple}";
        _appleCount = apple;
    }
    public void GameResult(bool _isClear){
        DataManager.instance.isClear = _isClear;
        DataManager.instance.appleCount = _appleCount;
        DataManager.instance.totalAppleCount = _totalAppleCount;
        DataManager.instance.achievement = _achievement;
    }
}
