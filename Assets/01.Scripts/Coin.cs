using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    StageManager stageManager;
    void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("PLAYER")){
            stageManager.CoinUpdate();
            Destroy(this.gameObject);
        }
    }
}
