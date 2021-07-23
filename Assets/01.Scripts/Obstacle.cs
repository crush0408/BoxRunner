using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("PLAYER")){
            // 시간 멈춰야함 그니까 MapMove
            // 플레이어 죽는 애니메이션 재생
            // 결과창 이동
        }
        if(col.gameObject.CompareTag("BOX")){
            //박스 부서짐 /박스 애니메이션 재생
            PoolManager.instance.ReturnObject(col.gameObject.GetComponent<BOX>());
        }
    }
}
