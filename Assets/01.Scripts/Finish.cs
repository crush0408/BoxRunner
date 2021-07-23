using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    StageManager stageManager;
    void Awake(){
        stageManager = FindObjectOfType<StageManager>();
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("PLAYER")){
            DataManager.instance.isPlaying = false;
            stageManager.GameResult(true);
            SceneManager.LoadScene("ClearOver");
        }
    }
}
