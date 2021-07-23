using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    BOX box;
    PlayerScript player;
    StageManager stageManager;
    void OnEnable() 
    {
        box = FindObjectOfType<BOX>();
        player = FindObjectOfType<PlayerScript>();
        stageManager = FindObjectOfType<StageManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PLAYER"))
        {
            Time.timeScale = 0f;
            //player.animator.
            // 플레이어 죽는 애니메이션 재생
            // 결과창 이동
            //Animation animation;
            //if(!(animation.IsPlaying("DEAD")))
            
            //stageManager.GameResult(false);
            //SceneManager.LoadScene("ClearOver");
        }
        if(box == null)
        {
            Debug.Log(box);
            return;
        }
        if (col.gameObject.CompareTag("BOX"))
        {
            Debug.Log("hi");
            box.animator.SetTrigger("IsDestroy");
            PoolManager.instance.ReturnObject(col.gameObject.GetComponent<BOX>());
        }
    }
    
}
